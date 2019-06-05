using SitePedro.Models;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;

namespace SitePedro.Controllers
{
    public class RegisterController : SurfaceController
    {
        [HttpGet]
        public ActionResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if ((Services.MemberService.GetByUsername(model.Username) != null) && (Services.MemberService.GetByEmail(model.Email) != null))
                {
                    TempData["Error"] = "Registration failed! Username and email already exist.";
                    return CurrentUmbracoPage();
                }

                if (Services.MemberService.GetByUsername(model.Username) != null)
                {
                    TempData["Error"] = "Registration failed! Username already exists.";
                    return CurrentUmbracoPage();
                }

                if (Services.MemberService.GetByEmail(model.Email) != null)
                {
                    TempData["Error"] = "Registration failed! Email already exists.";
                    return CurrentUmbracoPage();
                }

                Membership.CreateUser(model.Username, model.Password, model.Email);
                FormsAuthentication.SetAuthCookie(model.Username, false);
                UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
                TempData["Success"] = "Successfully registered!";
                return CurrentUmbracoPage();
            }
            return PartialView(model);
        }
    }
}