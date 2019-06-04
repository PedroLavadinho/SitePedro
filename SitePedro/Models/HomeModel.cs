using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;
using Umbraco.Web.Models;
using Umbraco.Core;
using System.Web.Mvc;
using System.Drawing;

namespace SitePedro.Models
{
    public class Home : ContentModel
    {
        public string Slogan
        {
            get { return Content.Value<string>("slogan"); }
        }

        public string ButtonText
        {
            get { return Content.Value<string>("buttonText"); }
        }

        public string ContactText
        {
            get { return Content.Value<string>("contactText"); }
        }

        public MvcHtmlString Video
        {
            get { return Content.Value<MvcHtmlString>("video"); }
        }

        public MvcHtmlString Background
        {
            get { return Content.Value<MvcHtmlString>("background"); }
        }

        public Home(IPublishedContent content) : base(content)
        {

        }



    }
}