using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using SitePedro.Models;

namespace SitePedro.Controllers
{
    public class LoginController : SurfaceController
    {
        public ActionResult RenderLogin()
        {
            return PartialView("Login", new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginModel.Username, loginModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.Username, false);
                    UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
                    if (myHelper.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        TempData["Success"] = "Successfully logged in!";
                        return Redirect("/home/");
                    }
                }
            }
            TempData["Error"] = "The username or password provided is incorrect.";
            return CurrentUmbracoPage();
        }

        public ActionResult Logout()
        {
            return PartialView("Logout", null);
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            TempData["Success"] = "Successfully logged out!";
            return Redirect("/home/");
        }
    }
}