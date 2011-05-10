using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MvcShop.Models;
using System.Web.Profile;
using System.Globalization;
using MvcShop.ServiceShop;

namespace MvcShop.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", Resources.Global.CorrectUser);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    ProfileBase p = ProfileBase.Create(Server.HtmlEncode(model.UserName), true);
                    p.SetPropertyValue("first", Server.HtmlEncode(model.Fisrt));
                    p.SetPropertyValue("last", Server.HtmlEncode(model.Last));
                    p.SetPropertyValue("address", Server.HtmlEncode(model.Address));
                    p.SetPropertyValue("phone", Server.HtmlEncode(model.Phone));
                    p.Save();
                    Roles.AddUserToRole(model.UserName, "user");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", Resources.Global.InvalidPass);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult UserInfo() 
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return Resources.Global.NameExist;

                case MembershipCreateStatus.DuplicateEmail:
                    return Resources.Global.EmailAddress;

                case MembershipCreateStatus.InvalidPassword:
                    return Resources.Global.PassError;

                case MembershipCreateStatus.InvalidEmail:
                    return Resources.Global.EmailInvalid;

                case MembershipCreateStatus.InvalidAnswer:
                    return Resources.Global.PassInvalid;

                case MembershipCreateStatus.InvalidQuestion:
                    return Resources.Global.PassInvalid1;

                case MembershipCreateStatus.InvalidUserName:
                    return Resources.Global.UserInvalid;

                case MembershipCreateStatus.ProviderError:
                    return Resources.Global.AuthenError;

                case MembershipCreateStatus.UserRejected:
                    return Resources.Global.CreateCan;

                default:
                    return Resources.Global.UnknownError;
            }
        }

        #endregion
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            var ssc = new ServiceShopClient();
            if (lang == "ru")
                ssc.SetShop("shop.mdf");
            else
                ssc.SetShop("shop_en.mdf");
            
            return Redirect(returnUrl);
        }

    }
}
