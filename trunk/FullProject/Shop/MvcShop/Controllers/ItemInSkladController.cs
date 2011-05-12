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
                ssc.Close();
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult AddQuantity(ItemInSklad item, string addQ)
        {
            if (addQ != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ItemInSklad it = ssc.LoadItemInSklad(item.Id);
                it.Quantity += item.Quantity;
                ssc.UpdateItemInSklad(it);
                ssc.Close();
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult Edit(ItemInSklad item, string edit, string ledit, string Id, string add, string countAdd, string ing)
        {
            if (add != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ItemInSklad it = ssc.LoadItemInSklad(item.Id);
                int i = 0;
                if (int.TryParse(countAdd, out i))
                    it.Quantity += i;
                ssc.UpdateItemInSklad(it);
                ssc.Close();
                return RedirectToAction("Index", "ItemInSklad");
            }
            if (ledit != null)
            {
                item.Ingridient = new Ingridient { Id = int.Parse(ing), IngridientName = "" };
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.UpdateItemInSklad(item);
                ssc.Close();
                return RedirectToAction("Index", "ItemInSklad");
            }

            ServiceShopClient ssc_ = new ServiceShopClient();
            ViewData["itemInSklad"] = ssc_.LoadItemInSklad(int.Parse(Id));
            ssc_.Close();
            return View();
        }

        public ActionResult Delete(ItemInSklad item, string delete)
        {
            if (delete != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                ssc.DeleteItemInSklad(item);
                ssc.Close();
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult IngredientsEnd()
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["itemInSklad"] = ssc.LoadAllItemInSklad();
            ssc.Close();

            return View();
        }
    }
}
