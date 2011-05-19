using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;

namespace MvcShop.Controllers
{
    public class CookBookController : Controller
    {
        //
        // GET: /CookBook/

        public ActionResult Index(string idCategory)
        {
            var ssc = new ServiceShopClient();
            ViewData["allCategory"] = new SelectList(ssc.LoadAllCategory(), "Id", "CategoryName");
            ViewData["allRecept"] = ssc.LoadAllRecept();
            int c;
            if (!int.TryParse(idCategory, out c)) c = 1;
            var recept = ssc.LoadReceptByCategory(c).ToList();
            ssc.Close();
            return View(recept);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Recept recept, string id)
        {
            var ssc = new ServiceShopClient();
            ssc.DeleteRecept(ssc.LoadRecept(int.Parse(id)));
            ssc.Close();
            return RedirectToAction("Index", "CookBook");
        }

        public ActionResult AddRecipe(Recept item, string cat, string add)
        {
            var ssc = new ServiceShopClient();
            ViewData["allCategory"] = new SelectList(ssc.LoadAllCategory(), "Id", "CategoryName");
            ViewData["listIngr"] = new SelectList(ssc.LoadAllIngridients(), "Id", "IngridientName");
            var recInCat = new ReceptInCategory();
            if (add != null)
            {
                item.Ingridients = new List<IngridientInRecept>();
                item.PathToImage = item.PathToImage ?? "";
                recInCat.IdRecept =ssc.CreateRecept(item);
                recInCat.IdCategory = int.Parse(cat);
                ssc.CreateReceptInCategory(recInCat);
                ssc.Close();
                return RedirectToAction("Index", "CookBook");
            }
            return View(item);
        }


        
        public ActionResult Edit(Recept recept, string edit,string update)
        {
            var ssc = new ServiceShopClient();
            var listIngr=new List<Ingridient> ();
            foreach (var ing in ssc.LoadAllIngridients())
            {
                var notInRecept = false;
                foreach (var ingr in ssc.LoadAllIngridientsInRecept(recept.Id)) {
                    if (ing.Id != ingr.Ingridient.Id) { notInRecept = true; }
                    else
                    {
                        notInRecept = false;
                        break;
                    }
                }
                if (notInRecept) listIngr.Add(ing);
                
            }
            ViewData["listIngr"] = new SelectList(listIngr, "Id", "IngridientName");
            var lIngr = new List<IngridientInRecept>();
            if (edit != null)
            {
                recept = ssc.LoadRecept(recept.Id);
                RedirectToAction("Index", "CookBook",recept);
            
            }
           
            if (update != null)
            {
                recept.Ingridients = lIngr;
                recept.PathToImage = recept.PathToImage ?? "";
                ssc.UpdateRecept(recept);
                ssc.Close();
                return RedirectToAction("Index", "CookBook");
            }
            return View(recept);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddIn(string ingId, string add, string idRec,string quantity) {

            if (add != null)
            {
                var ssc = new ServiceShopClient();
                var newIngr = new IngridientInRecept
                                  {
                                      Ingridient = ssc.LoadIngridient(int.Parse(ingId)),
                                      Quantity = int.Parse(quantity),
                                      IdRecept = int.Parse(idRec)
                                  };
                ssc.CreateIngridientInRecept(newIngr);
                ssc.Close();
            }//!!!!!!!!!!!!
            return RedirectToAction("Index");//остаться на стр!!!!!!!!!!!!!!!
          
        }


        public ActionResult DelIngr(IngridientInRecept ingridientInRecept,string idRec,string idInRec,  string delete)
        {
            
            
            if (delete != null)
            { 
                var ssc = new ServiceShopClient();
                ssc.DeleteIngridientInRecept(ssc.LoadIngridientInReceptById(int.Parse(idInRec)));
                ssc.Close();  
            }
            return RedirectToAction("Index");
          }

        public ActionResult EditIngr(string ingr,string idInRec,string quantity, string editIngr)
        {
            var ssc = new ServiceShopClient();
            ViewData["allIngr"] = new SelectList(ssc.LoadAllIngridients(), "Id", "IngridientName");
            var ingrInRecept = ssc.LoadIngridientInReceptById(int.Parse(idInRec));// new IngridientInRecept { Id = int.Parse(IdInRec), Quantity = int.Parse(q) };
            ingrInRecept.Quantity = int.Parse(quantity);
            if (editIngr != null)
            {
                {
                    ssc.UpdateIngridientInRecept(ingrInRecept);
                    ssc.Close();
                }
            }
            return RedirectToAction("Index");
        }
    }

}
