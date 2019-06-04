using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace SitePedro.Models
{
    public class MembersPageModel : ContentModel
    {
        public MembersPageModel(IPublishedContent content) : base(content)
        {
        }

        public List<MembersModel> UmbUsers { get; set; }

        public ProfileModel Person { get; set; }



    }
}