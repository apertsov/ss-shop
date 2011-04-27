using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcShop.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager1/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Role(string Name, string a, string delete, string role)
        {
            if(Name!=null)
            if(!Roles.RoleExists(Name))
            Roles.CreateRole(Name); 
            if(delete!=null)
                Roles.DeleteRole(role);
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string role, string delete)
        {
            if (delete != null)
            {
                string[] user = Roles.GetUsersInRole(role);
                if (user.Length!=0)
                   Roles.RemoveUsersFromRole(Roles.GetUsersInRole(role),role);
                Roles.DeleteRole(role);
            }
            return RedirectToAction("Role","Manager");
        }

        public ActionResult UserRole()
        {
            return View();
        }
    }
}
