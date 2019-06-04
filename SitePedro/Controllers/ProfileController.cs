using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using SitePedro.Models;

namespace SitePedro.Controllers
{
    [Authorize]
    public class ProfileController : RenderMvcController
    {
        [HttpGet]
        public ActionResult ProfilePage(ContentModel content)
        {
            var membershipUser = Membership.GetUser();
            var user = Services.MemberService.GetById((int)membershipUser.ProviderUserKey);
            var returnModel = new ProfilePageModel(content.Content)
            {
                Profile = new Models.ProfileModel()
                {
                    NameandSurname = user.GetValue<string>("nameAndSurname"),
                    Birthday = user.GetValue<string>("birthday"),
                    Weight = user.GetValue<int>("weight"),
                    Height = user.GetValue<int>("height"),
                    HairColor = user.GetValue<string>("hairColor"),
                    EyeColor = user.GetValue<string>("eyeColor"),
                }
            };

                var avatarId = user.GetValue<int>("avatar");

                var avatar = UmbracoContext.MediaCache.GetById(avatarId);

            if (avatar != null)
            {
                returnModel.Profile.ImagemUrl = avatar.Url;
            }
            else
            {
                return CurrentTemplate(returnModel);
            }

            return CurrentTemplate(returnModel);
        }
    }
}