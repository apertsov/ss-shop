using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class TellerController : Controller
    {
        //
        // GET: /Teller/

        public ActionResult Index()
        {
            ServiceShopClient ssc = new ServiceShopClient();
            
            ShopModel.Entities.Order[] orderList;
            /*
            ShopModel.Entities.Order[] newOrderList;
            orderList = ssc.LoadAllOrder();
            foreach (ShopModel.Entities.Order order in orderList)
            {
                var os = (int)order.OrderStatus;
                
            }

            List<Order> lO = new List<Order>();
            ShopModel.Entities.Order ord;
            */
            ViewData["endOrders"] = ssc.LoadAllOrder(); //orderList; 
            return View();
        }

    }
}
