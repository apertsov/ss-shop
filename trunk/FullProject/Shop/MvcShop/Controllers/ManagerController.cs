using System.Web.Mvc;
using System.Web.Security;
using System.Web.Profile;
using System;
using MvcShop.ServiceShop;
using System.Linq;
namespace MvcShop.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager1/

        public ActionResult Index()
        {
            if (!User.IsInRole("manager")) return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult Role()
        {
            if (!User.IsInRole("manager")) RedirectToAction("Index", "Home");
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Role(string name, string a, string delete, string role)
        {
            if (!User.IsInRole("manager")) RedirectToAction("Index", "Home");
            if(name!=null)
            if(!Roles.RoleExists(name))
            Roles.CreateRole(name); 
            if(delete!=null) Roles.DeleteRole(role);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(string role, string delete)
        {
            if (!User.IsInRole("manager")) RedirectToAction("Index", "Home");
            if (delete != null)
            {
                string[] user = Roles.GetUsersInRole(role);
                if (user.Length!=0)
                   Roles.RemoveUsersFromRole(Roles.GetUsersInRole(role),role);
                Roles.DeleteRole(role);
            }
            return RedirectToAction("Role","Manager");
        }


        public ActionResult AddUser()
        {
            if (!User.IsInRole("manager")) RedirectToAction("Index", "Home");
            return View();
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddUser(string login,string password,string first,string last,string address,string phone,FormCollection fc)
        {
            if (!User.IsInRole("manager")) return RedirectToAction("Index", "Home");
                MembershipCreateStatus createStatus;
                Membership.CreateUser(Server.HtmlEncode(fc["login"]),Server.HtmlEncode(fc["password"]), null, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    
                    FormsAuthentication.SetAuthCookie(Server.HtmlEncode(fc["login"]), false /* createPersistentCookie */);
                    ProfileBase p = ProfileBase.Create(Server.HtmlEncode(fc["login"]), true);
                    p.SetPropertyValue("first", Server.HtmlEncode(fc["first"]));
                    p.SetPropertyValue("last", Server.HtmlEncode(fc["last"]));
                    p.SetPropertyValue("address", Server.HtmlEncode(fc["address"]));
                    p.SetPropertyValue("phone", Server.HtmlEncode(fc["phone"]));
                    p.Save();
                    foreach (string role in Roles.GetAllRoles())
                    {
                       // var r = fc[role];
                        if (fc[role] != "false")
                            Roles.AddUserToRole(login, role);
                    }
                    return RedirectToAction("Index", "Manager");
                }
                     
            return View();
        }



        public ActionResult ChangeUser()
        {
            if (!User.IsInRole("manager")) return RedirectToAction("Index", "Home");
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangeUser(FormCollection fc)
        {
            if (!User.IsInRole("manager")) return RedirectToAction("Index", "Home");
            if (fc["save"] != null)
            {
                foreach (var item in Membership.GetAllUsers())
                {
                    var user = (MembershipUser)item;
                    foreach (var name in Roles.GetAllRoles())
                    {
                        if (fc[name + user.UserName] != "false")
                            if (!Roles.IsUserInRole(user.UserName, name))
                            Roles.AddUserToRole(user.UserName, name);
                    }
                }
            }
            return RedirectToAction("ChangeUser", "Manager");
        }


        public ActionResult DeleteUser(string user, string x)
        {
            if (!User.IsInRole("manager")) return RedirectToAction("Index", "Home");
            if (x != null)
                Membership.DeleteUser(user);
            return RedirectToAction("ChangeUser", "Manager");
          
        }

        public ActionResult GetAllOrders()
        {
            if (!User.IsInRole("manager")) return RedirectToAction("Index", "Home");
            var ssc = new ServiceShopClient();
            ViewData["orders"] = ssc.LoadAllOrder();
            ssc.Close();

            return View();
        }   
    }
}
