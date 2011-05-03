using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class IngridientController : Controller
    {
        //
        // GET: /Ingridient/

        public ActionResult Index()
        {
            var ssc = new ServiceShopClient();
            ViewData["ingradients"] = ssc.LoadAllIngridients();
            
            return View();
        }

        public ActionResult Add(Ingridient ing, string add)
        {
            if (add != null)
            {
                var ssc = new ServiceShopClient();
                ssc.CreateIngridient(ing);
            }

            return RedirectToAction("Index", "Ingridient");
        }

        public ActionResult Edit(Ingridient ing, string edit)
        {
            if (edit != null)
            {
                var ssc = new ServiceShopClient();
                ssc.UpdateIngridient(ing);
            }

            return RedirectToAction("Index", "Ingridient");
        }

        public ActionResult Delete(Ingridient ing, string delete)
        {
            if (delete != null)
            {
                var ssc = new ServiceShopClient();
                ssc.DeleteIngridient(ing);
            }

            return RedirectToAction("Index", "Ingridient");
        }
    }
}
