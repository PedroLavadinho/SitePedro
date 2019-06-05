using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using SitePedro.Models;

namespace SitePedro.Controllers
{
    public class MembersPageController : RenderMvcController
    {
        [HttpGet]
        public ActionResult MembersPage(ContentModel content)
        {
            var umbUsers = new List<MembersModel>();
            var allUsers = Services.MemberService.GetAllMembers();
            var persons = new MembersPageModel(content.Content);
            foreach (var item in allUsers)
            {

                var NameandSurname = item.GetValue<string>("nameAndSurname");

                var avatarId = item.GetValue<int>("avatar");

                var avatar = UmbracoContext.MediaCache.GetById(avatarId);

                var umbUser = new MembersModel();

                umbUser.NameandSurname = NameandSurname;

                if (item.GetValue("avatar") != null)
                {
                    umbUser.Avatar = avatar;
                    umbUser.ImagemUrl = avatar.Url;
                }



                umbUsers.Add(umbUser);


            }
            persons.UmbUsers = umbUsers;

            return CurrentTemplate(persons);

        }
    }
}