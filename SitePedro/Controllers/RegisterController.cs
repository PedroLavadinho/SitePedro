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
                Membership.CreateUser(model.Username, model.Password, model.Email);
                FormsAuthentication.SetAuthCookie(model.Username, false);
                UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
                TempData["Success"] = "Successfully registered!";
                return RedirectToCurrentUmbracoPage();
            }
            return PartialView(model);
        }
    }
}