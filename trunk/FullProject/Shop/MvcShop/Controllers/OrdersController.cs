using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Orders/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetById(string orderId, string getByOrderId)
        {
            ViewData["sId"] = orderId;
            if (getByOrderId != null)
            {
                int id;
                if (int.TryParse(orderId,out id))
                {
                    var ssc = new ServiceShopClient();
                    return View("SearchById", ssc.LoadOrder(id));
                }
            }
            return View("SearchById",null);
        }

        public ActionResult GetByUser(string dtFrom, string dtTo,string getByOrderUser)
        {
            ViewData["dtFrom"] = dtFrom;
            ViewData["dtTo"] = dtTo;
            if (getByOrderUser != null)
            {
                try
                {
                    var dFrom = DateTime.Parse(dtFrom);
                    var dTo = DateTime.Parse(dtTo);
                    var ssc = new ServiceShopClient();
                    var lOrder = ssc.LoadOrderByUserName(User.Identity.Name??"").ToList();
                    lOrder = lOrder.Where(lo => lo.Start >= dFrom).Where(lo => lo.Start <= dTo).ToList();
                    return View("SearchByUser", lOrder);
                }
                catch (Exception)
                {
                    return View("SearchByUser", null);
                }
                
            }
            return View("SearchByUser", null);
        }
    }
}
