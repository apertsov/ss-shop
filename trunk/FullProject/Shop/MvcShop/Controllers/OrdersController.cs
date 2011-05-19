using System;
using System.Linq;
using System.Resources;
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
            if (User.Identity.IsAuthenticated)
            {
                var ssc = new ServiceShopClient();
                Order order;
                try
                {
                    order = ssc.LoadOrderByUserName(User.Identity.Name).Last();
                }
                catch
                {
                    return View();
                }
                ssc.Close();
                return View(order);    
            }
            else
            {
                var cookie = Request.Cookies["mvcShop"];
                Order order = null;
                if (cookie != null)
                {
                    int id;
                    if (int.TryParse(cookie.Value, out id))
                    {
                        var ssc = new ServiceShopClient();
                        order = ssc.LoadOrder(id);
                        ssc.Close();
                    }
                }
                return View(order);    
            }
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
                ssc.Close();
                s = order == null ?Resources.Global.UOrder : string.Format("<b>{0}</b> ", order.OrderStatus);
            }
            else
            {
                s = Resources.Global.UOrder;
            }
            s += String.Format("<br/>last query:{0}",DateTime.Now);
            return s;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public string GetOrderDataById(string id)
        {
            var s = Resources.Global.UOrder;
            int idI;
            var rm = new ResourceManager("Resources.Recept", System.Reflection.Assembly.Load("App_GlobalResources"));
            if (int.TryParse(id, out idI))
            {
                var ssc = new ServiceShopClient();
                var order = ssc.LoadOrder(idI);
                ssc.Close();
                if (order != null)
                {
                    s = "<table>";
                    s += string.Format("<tr><th>{1}:</th><td>{0}</td></tr>", order.Name, Resources.Global.FirstName);
                    s += string.Format("<tr><th>{1}:</th><td>{0}</td></tr>", order.Phone,Resources.Global.Phone);
                    s += string.Format("<tr><th>{1}:</th><td>{0}</td></tr>", order.Address, Resources.Global.Address);
                    s+="<tr><th>"+Resources.Global.Item+":</th><td>";
                    if (order.OrderLines.Count > 0) {
                        s += "<table><thead><tr><th>" + Resources.Global.FirstName + "</th><th>" + Resources.Global.Quantity + "</th><th>" + Resources.Global.Price + "</th></tr></thead><tbody>";
                        s = order.OrderLines.Aggregate(s, (current, orderLine) => current + string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td> </tr>", rm.GetString('r'+orderLine.Recept.Id.ToString()), orderLine.Quantity, orderLine.Quantity*orderLine.Recept.Price));
                        s += "</tbody><tfoot><tr><td colspan=\"2\" align=\"right\">" + Resources.Global.Total + "</td>";
                        s+=string.Format("<td>{0}</td></tr></tfoot></table>",order.ComputeTotalValue());
                    }
                    s += string.Format("</td></tr><tr><th>{1}:</th><td>{0}</td></tr>", order.Start, Resources.Global.OrderDateTime);
                    s += string.Format("<tr><th>{1}:</th><td>{0}</td></tr>", (order.Start == order.OnDateTime) ? "fastest" : order.OnDateTime.ToString(), Resources.Global.OrderDateTime);
                    s += string.Format("<tr><th>{1}:</th><td>{0}</td></tr>", order.OrderStatus, Resources.Global.OrderStatus);
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
                    ssc.Close();
                    lOrder = lOrder.Where(lo => lo.Start >= dFrom).Where(lo => lo.Start <= dTo).ToList();
                    return View("SearchByUser", lOrder.Count>0?lOrder:null);
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
