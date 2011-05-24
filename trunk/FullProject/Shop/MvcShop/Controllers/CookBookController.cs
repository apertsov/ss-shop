using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcShop.ServiceShop;
using ShopModel.Entities;
using System.Resources;
using System.Globalization;
using System.Collections;
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

        public ActionResult AddRecipe(Recept item, string cat, string add, FormCollection fc)
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
                //(Server.MapPath("App_GlobalResources/myresource.resx")):
                ResXResourceReader rsxr = new ResXResourceReader(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.resx");
                List<DictionaryEntry> l=new List<DictionaryEntry>();
                foreach (DictionaryEntry d in rsxr)
                l.Add(d);
                rsxr.Close();
                //rsxw.AddResource(r);
                ResXResourceWriter rsxw = new ResXResourceWriter(Request.PhysicalApplicationPath +"App_GlobalResources\\" + "Recept.resx");
                foreach(DictionaryEntry d in l)
                    rsxw.AddResource(d.Key.ToString(),d.Value);
                rsxw.AddResource("r" +recInCat.IdRecept,  item.NameRecept);
                rsxw.AddResource("d" + recInCat.IdRecept, fc["description"]);
                rsxw.Generate();
                rsxw.Close();

                
                rsxw = new ResXResourceWriter(Request.PhysicalApplicationPath +"App_GlobalResources\\"+"Recept.ru.resx");
                rsxr = new ResXResourceReader(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.ru.resx");
                l=new List<DictionaryEntry>();
                foreach (DictionaryEntry d in rsxr)
                l.Add(d);
                rsxr.Close();
                foreach(DictionaryEntry d in l)
                    rsxw.AddResource(d.Key.ToString(),d.Value);
                rsxw.AddResource("d" + recInCat.IdRecept, fc["description1"]);
                rsxw.AddResource("r" + recInCat.IdRecept, fc["NameRecept1"]);
                rsxw.Close();

                rsxw = new ResXResourceWriter(Request.PhysicalApplicationPath +"App_GlobalResources\\"+"Recept.uk-UA.resx");
                rsxr = new ResXResourceReader(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.uk-UA.resx");
                l=new List<DictionaryEntry>();
                foreach (DictionaryEntry d in rsxr)
                l.Add(d);
                rsxr.Close();
                foreach(DictionaryEntry d in l)
                    rsxw.AddResource(d.Key.ToString(),d.Value);
                rsxw.AddResource("d" + recInCat.IdRecept, fc["description2"]);
                rsxw.AddResource("r" + recInCat.IdRecept, fc["NameRecept2"]);
                rsxw.Close(); 
               
                ssc.Close();
                return RedirectToAction("Index", "CookBook");
            }
            return View(item);
        }


        
        public ActionResult Edit(Recept recept, string edit,string update, FormCollection fc)
        {
            var ssc = new ServiceShopClient();
            var rm = new ResourceManager("Resources.Recept", System.Reflection.Assembly.Load("App_GlobalResources"));
            ViewData["name"] = rm.GetString("r"+recept.Id, new CultureInfo("en"));
            ViewData["nameru"] = rm.GetString("r" + recept.Id, new CultureInfo("ru"));
            ViewData["nameua"] = rm.GetString("r" + recept.Id, new CultureInfo("uk-UA"));

            ViewData["dname"] = rm.GetString("d"+recept.Id, new CultureInfo("en"));
            ViewData["dnameru"] = rm.GetString("d" + recept.Id, new CultureInfo("ru"));
            ViewData["dnameua"] = rm.GetString("d" + recept.Id, new CultureInfo("uk-UA"));

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
                ResXResourceReader rsxr = new ResXResourceReader(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.resx");
                List<DictionaryEntry> l = new List<DictionaryEntry>();
                foreach (DictionaryEntry d in rsxr)
                    l.Add(d);
                rsxr.Close();
                //rsxw.AddResource(r);
                ResXResourceWriter rsxw = new ResXResourceWriter(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.resx");
                foreach (DictionaryEntry d in l)
                    if (d.Key.ToString() != "r" + recept.Id)
                    rsxw.AddResource(d.Key.ToString(), d.Value);
                rsxw.AddResource("r" + recept.Id, recept.NameRecept);
                rsxw.AddResource("d" + recept.Id, fc["description"]);
                rsxw.Generate();
                rsxw.Close();


                rsxw = new ResXResourceWriter(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.ru.resx");
                rsxr = new ResXResourceReader(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.ru.resx");
                l = new List<DictionaryEntry>();
                foreach (DictionaryEntry d in rsxr)
                    l.Add(d);
                rsxr.Close();
                foreach (DictionaryEntry d in l)
                    if (d.Key.ToString() != "r" + recept.Id)
                    rsxw.AddResource(d.Key.ToString(), d.Value);
                rsxw.AddResource("d" + recept.Id, fc["description1"]);
                rsxw.AddResource("r" + recept.Id, fc["NameRecept1"]);
                rsxw.Close();

                rsxw = new ResXResourceWriter(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.uk-UA.resx");
                rsxr = new ResXResourceReader(Request.PhysicalApplicationPath + "App_GlobalResources\\" + "Recept.uk-UA.resx");
                l = new List<DictionaryEntry>();
                foreach (DictionaryEntry d in rsxr)
                    l.Add(d);
                rsxr.Close();
                foreach (DictionaryEntry d in l)
                    if (d.Key.ToString() != "r" + recept.Id)
                    rsxw.AddResource(d.Key.ToString(), d.Value);
                rsxw.AddResource("d" + recept.Id, fc["description2"]);
                rsxw.AddResource("r" + recept.Id, fc["NameRecept2"]);
                rsxw.Close(); 
               
                
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
