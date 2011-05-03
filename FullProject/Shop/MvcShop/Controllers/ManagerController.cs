using System.Web.Mvc;
using System.Web.Security;
using System.Web.Profile;

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
        public ActionResult Role(string name, string a, string delete, string role)
        {
            if(name!=null)
            if(!Roles.RoleExists(name))
            Roles.CreateRole(name); 
            if(delete!=null)
                Roles.DeleteRole(role);
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


        public ActionResult AddUser()
        {
            return View();
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddUser(string login,string password,string first,string last,string address,string phone,FormCollection fc)
        {
            
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
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ChangeUser(FormCollection fc)
        {
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
            if (x != null)
                Membership.DeleteUser(user);
            return RedirectToAction("ChangeUser", "Manager");
          
        }
    }
}
