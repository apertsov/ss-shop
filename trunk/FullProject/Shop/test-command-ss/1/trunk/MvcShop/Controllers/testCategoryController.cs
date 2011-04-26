using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc. PartyInvites.Models;
using ShopModel.Entities;
namespace MvcShop.Controllers
{
    public class testCategoryController : Controller
    {
        //
        // GET: /testCategory/
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categorys(Category cat,string sa,string sb,string sc)
        {
            if (sa!=null)
            cat.Create();
            if (sb != null)
                cat.Delete();
            if (sc != null)
                cat.Update();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Categorys()
        {
             return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Recept()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recept(Recept cat, string sa, string sb, string sc)
        {
            if (sa != null)
                cat.Create();
            if (sb != null)
                cat.Delete();
            if (sc != null)
                cat.Update();
            return View();
        }
    }
}
