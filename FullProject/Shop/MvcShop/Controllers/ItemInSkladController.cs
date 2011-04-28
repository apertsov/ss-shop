using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class ItemInSkladController : Controller
    {
        //
        // GET: /ItemInSklad/

        public ActionResult Index()
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["itemInSklad"] = ssc.LoadAllItemInSklad();
            ViewData["IngridientID"] = new SelectList(ssc.LoadAllIngridients(), "Id", "IngridientName");

            return View();
        }

        public ActionResult Add(ItemInSklad item, string add, string ing)
        {
            if (add != null)
            {
                item.Ingridient = new Ingridient { Id = int.Parse(ing), IngridientName = "" };
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.CreateItemInSklad(item);
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult Edit(ItemInSklad item, string edit, string ing)
        {
            if (edit != null)
            {
                item.Ingridient = new Ingridient { Id = int.Parse(ing), IngridientName = "" };
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.UpdateItemInSklad(item);
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult Delete(ItemInSklad item, string delete)
        {
            if (delete != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.DeleteItemInSklad(item);
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

    }
}
