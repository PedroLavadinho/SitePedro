using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace SitePedro.Models
{
    public class ProfilePageModel : ContentModel
    {
        public ProfilePageModel(IPublishedContent content) : base(content)
        {

        }

        public ProfileModel Profile { get; set; }
    }
}