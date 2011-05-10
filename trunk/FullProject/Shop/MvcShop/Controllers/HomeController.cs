using System.Web.Mvc;
using MvcShop.ServiceShop;

namespace MvcShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("manager"))
            {
                return RedirectToAction("Index", "Manager");
            }
            if (Session["Culture"] == null)
            {
                var ssc = new ServiceShopClient();
                ssc.SetShop("shop.mdf");
            }
            ViewBag.Message = Resources.Global.Home;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
