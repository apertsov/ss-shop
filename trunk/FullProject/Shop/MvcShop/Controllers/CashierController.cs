using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class CashierController : Controller
    {
        //
        // GET: /Cashier/

        public ActionResult Index()
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["ordersPrepared"] = ssc.LoadOrderByStatus(OrderStatus.Prepared);
            ViewData["ordersTaken"] = ssc.LoadOrderByStatus(OrderStatus.Taken);
            ssc.Close();
            
            return View();
        }

        public ActionResult Confirm(Order order, string confirm, string cancel, string send)
        {
            if (confirm != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                order = ssc.LoadOrder(order.Id);
                order.OrderStatus = OrderStatus.Processed;
                ssc.UpdateOrder(order);
                ssc.Close();
            }
            if (cancel != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                order = ssc.LoadOrder(order.Id);
                order.OrderStatus = OrderStatus.Canseled;
                ssc.UpdateOrder(order);
                ssc.Close();
            }

            if (send != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                order = ssc.LoadOrder(order.Id);
                order.OrderStatus = OrderStatus.End;
                ssc.UpdateOrder(order);
                ssc.Close();
            }
            return RedirectToAction("Index", "Cashier");
        }
    }
}
