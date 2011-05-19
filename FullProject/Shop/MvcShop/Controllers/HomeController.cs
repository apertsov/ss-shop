using System.Web.Mvc;

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
            ViewBag.Message = Resources.Global.Home;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
