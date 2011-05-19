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
            var ssc = new ServiceShopClient();
            ViewData["itemInSklad"] = ssc.LoadAllItemInSklad();
            ViewData["IngridientID"] = new SelectList(ssc.LoadAllIngridients(), "Id", "IngridientName");

            return View();
        }

        public ActionResult Add(ItemInSklad item, string add, string ing)
        {
            if (add != null)
            {
                item.Ingridient = new Ingridient { Id = int.Parse(ing), IngridientName = "" };
                var ssc = new ServiceShopClient();

                ssc.CreateItemInSklad(item);
                ssc.Close();
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult AddQuantity(ItemInSklad item, string addQ)
        {
            if (addQ != null)
            {
                var ssc = new ServiceShopClient();
                var it = ssc.LoadItemInSklad(item.Id);
                it.Quantity += item.Quantity;
                ssc.UpdateItemInSklad(it);
                ssc.Close();
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult Edit(ItemInSklad item, string edit, string ledit, string id, string add, string countAdd, string ing)
        {
            if (add != null)
            {
                var ssc = new ServiceShopClient();
                var it = ssc.LoadItemInSklad(item.Id);
                int i;
                if (int.TryParse(countAdd, out i))
                    it.Quantity += i;
                ssc.UpdateItemInSklad(it);
                ssc.Close();
                return RedirectToAction("Index", "ItemInSklad");
            }
            if (ledit != null)
            {
                item.Ingridient = new Ingridient { Id = int.Parse(ing), IngridientName = "" };
                var ssc = new ServiceShopClient();
                ssc.UpdateItemInSklad(item);
                ssc.Close();
                return RedirectToAction("Index", "ItemInSklad");
            }

            var ssc1 = new ServiceShopClient();
            ViewData["itemInSklad"] = ssc1.LoadItemInSklad(int.Parse(id));
            ssc1.Close();
            
            return View();
        }

        public ActionResult Delete(ItemInSklad item, string delete)
        {
            if (delete != null)
            {
                var ssc = new ServiceShopClient();
                ssc.DeleteItemInSklad(item);
                ssc.Close();
            }

            return RedirectToAction("Index", "ItemInSklad");
        }

        public ActionResult IngredientsEnd()
        {
            var ssc = new ServiceShopClient();
            ViewData["itemInSklad"] = ssc.LoadAllItemInSklad();
            ssc.Close();

            return View();
        }
    }
}
