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
            string s;
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

        [AcceptVerbs(HttpVerbs.Post)]
        public string GetOrderDataById(string id)
        {
            string s="<b>undefined status order</b> ";
            int idI;
            if (int.TryParse(id, out idI))
            {
                var ssc = new ServiceShopClient();
                var order = ssc.LoadOrder(idI);
                if (order != null)
                {
                    s = "<table>";
                    s += string.Format("<tr><th>Name:</th><td>{0}</td></tr>", order.Name);
                    s += string.Format("<tr><th>Phone:</th><td>{0}</td></tr>", order.Phone);
                    s += string.Format("<tr><th>Address:</th><td>{0}</td></tr>", order.Address);
                    s+="<tr><th>Items:</th><td>";
                    if (order.OrderLines.Count > 0) {
                        s+="<table><thead><tr><th>Name</th><th>Quantity</th><th>Price</th></tr></thead><tbody>";
                        s = order.OrderLines.Aggregate(s, (current, orderLine) => current + string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td> </tr>", orderLine.Recept.NameRecept, orderLine.Quantity, orderLine.Quantity*orderLine.Recept.Price));
                        s+="</tbody><tfoot><tr><td colspan=\"2\" align=\"right\">Total</td>";
                        s+=string.Format("<td>{0}</td></tr></tfoot></table>",order.ComputeTotalValue());
                    }
                    s+=string.Format("</td></tr><tr><th>Order DateTime:</th><td>{0}</td></tr>",order.Start);
                    s+=string.Format("<tr><th>Order on DateTime:</th><td>{0}</td></tr>",(order.Start==order.OnDateTime)?"fastest":order.OnDateTime.ToString());
                    s += string.Format("<tr><th>Order Status:</th><td>{0}</td></tr>", order.OrderStatus);
                    s += "</table>";
                }
            }
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
