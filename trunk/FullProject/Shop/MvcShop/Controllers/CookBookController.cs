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

        public ActionResult Index(string idCategory)
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["allCategory"] = new SelectList(ssc.LoadAllCategory(), "Id", "CategoryName");
            ViewData["allRecept"] = ssc.LoadAllRecept();
            List<Recept> recept = new List<Recept>();
            int c = 1;
            if (!int.TryParse(idCategory, out c)) c = 1;
            foreach (Recept rec in ssc.LoadReceptByCategory(c))
                recept.Add(rec);

            return View(recept);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Recept recept, string id)
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ssc.DeleteRecept(ssc.LoadRecept(int.Parse(id)));
            return RedirectToAction("Index", "CookBook");
        }

        public ActionResult AddRecipe(Recept item, string cat, string add)
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["allCategory"] = new SelectList(ssc.LoadAllCategory(), "Id", "CategoryName");
            ViewData["listIngr"] = new SelectList(ssc.LoadAllIngridients(), "Id", "IngridientName");
            ReceptInCategory recInCat = new ReceptInCategory();
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


        
        public ActionResult Edit(Recept recept, string Edit,string update)
        {
            ServiceShopClient ssc = new ServiceShopClient();
            List <Ingridient> listIngr=new List<Ingridient> ();
            foreach (Ingridient ing in ssc.LoadAllIngridients())
            {
                bool notInRecept = false;
                foreach (IngridientInRecept ingr in ssc.LoadAllIngridientsInRecept(recept.Id)) {
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
            List<IngridientInRecept> lIngr = new List<IngridientInRecept>();
            if (Edit != null)
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
        public ActionResult addIn(string ingID, string add, string IdRec,string quantity) {

            if (add != null)
            {
                ServiceShopClient ssc = new ServiceShopClient();
                IngridientInRecept newIngr = new IngridientInRecept();
                newIngr.Ingridient = ssc.LoadIngridient(int.Parse(ingID));
                Recept rec= ssc.LoadRecept(int.Parse(IdRec));
               
                newIngr.Quantity = int.Parse(quantity);
                newIngr.IdRecept = int.Parse(IdRec);
                ssc.CreateIngridientInRecept(newIngr);
                ssc.Close();
            }//!!!!!!!!!!!!
            return RedirectToAction("Index");//остаться на стр!!!!!!!!!!!!!!!
          
        }


        public ActionResult DelIngr(IngridientInRecept ingridientInRecept,string IdRec,string IdInRec,  string delete)
        {
            ServiceShopClient ssc = new ServiceShopClient();
            
            if (delete != null)
            {   {
                ssc.DeleteIngridientInRecept(ssc.LoadIngridientInReceptById(int.Parse(IdInRec)));
                    ssc.Close();
                }
            }
            return RedirectToAction("Index");
          }

        public ActionResult EditIngr(string ingr,string IdInRec,string quantity, string editIngr)
        {
            ServiceShopClient ssc = new ServiceShopClient();
            ViewData["allIngr"] = new SelectList(ssc.LoadAllIngridients(), "Id", "IngridientName");
            IngridientInRecept ingrInRecept = ssc.LoadIngridientInReceptById(int.Parse(IdInRec));// new IngridientInRecept { Id = int.Parse(IdInRec), Quantity = int.Parse(q) };
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
