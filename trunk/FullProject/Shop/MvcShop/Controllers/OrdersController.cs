using System;
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
            var cookie = Request.Cookies["mvcShop"];
            Order order = null;
            if (cookie!=null)
            {
                int id;
                if (int.TryParse(cookie.Value,out id))
                {
                    var ssc = new ServiceShopClient();
                    order = ssc.LoadOrder(id);
                }
            }
            return View(order);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public string GetStatusById(string id)
        {
            var s = id;
            int idI;
            if (int.TryParse(id,out idI))
            {
                var ssc = new ServiceShopClient();
                var order = ssc.LoadOrder(idI);
                s = order == null ? "<b>undefined status order</b> " : string.Format("<b>{0}</b> ", order.OrderStatus);
            }
            else
            {
                s = "<b>undefined status order</b> ";
            }
            s += String.Format("<br/>last query:{0}",DateTime.Now);
            return s;
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
