using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class KitchenController : Controller
    {
        //
        // GET: /Kitchen/

        public ActionResult Index()
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["orders"] = ssc.LoadOrderByStatus(OrderStatus.Processed);
            ssc.Close();

            return View();
        }

        public ActionResult Confirm(Order order, string confirm)
        {
            if (confirm != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                order = ssc.LoadOrder(order.Id);
                order.OrderStatus = OrderStatus.Prepared;
                ssc.UpdateOrder(order);
                ssc.Close();
            }
            
            return RedirectToAction("Index", "Kitchen");
        }

    }
}
