using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitePedro.Models;
using Umbraco.Core.Composing.CompositionExtensions;
using Umbraco.Web.Mvc;

namespace SitePedro.Controllers
{
    public class ContactController : SurfaceController
    {
        [HttpGet]
        public ActionResult ContactInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactInfo(ContactInfoModel contactInfoModel)
        {
            var contactentries = Services.ContentService.GetById(1255);
            contactentries.

            return View();
        }
    }
}