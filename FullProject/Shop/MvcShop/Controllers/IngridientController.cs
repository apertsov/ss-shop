using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["ingradients"] = ssc.LoadAllIngridients();
            
            return View();
        }

        public ActionResult Add(Ingridient ing, string add)
        {
            if (add != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.CreateIngridient(ing);
            }

            return RedirectToAction("Index", "Ingridient");
        }

        public ActionResult Edit(Ingridient ing, string edit)
        {
            if (edit != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.UpdateIngridient(ing);
            }

            return RedirectToAction("Index", "Ingridient");
        }

        public ActionResult Delete(Ingridient ing, string delete)
        {
            if (delete != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.DeleteIngridient(ing);
            }

            return RedirectToAction("Index", "Ingridient");
        }

        //тестовий контроллер для наповнення тестовми даними.
        //в майбутньому його варто відключити
        public ActionResult testAdd()
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ssc.CreateIngridient(new Ingridient { Id = 1, IngridientName = "Salt"} );
            ssc.CreateIngridient(new Ingridient { Id = 1, IngridientName = "Sugar"});
            ssc.CreateIngridient(new Ingridient { Id = 1, IngridientName = "Paper"});

            return RedirectToAction("Index", "Ingridient");
        }
    }
}
