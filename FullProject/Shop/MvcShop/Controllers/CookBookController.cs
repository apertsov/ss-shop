using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class CookBookController : Controller
    {
        //
        // GET: /CookBook/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRecipe(Recept item, string add)
        {
            if (add != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.CreateRecept(item);
                return RedirectToAction("Index", "CookBook");
            }

            return View();
        }
    }
}
