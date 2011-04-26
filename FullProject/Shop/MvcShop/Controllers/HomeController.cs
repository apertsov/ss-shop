using System.Web.Mvc;

namespace MvcShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "on-line shop";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
