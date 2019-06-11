using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using SitePedro.Models;

namespace SitePedro.Controllers
{
    public class ContactEntriesController : RenderMvcController
    {

        [HttpGet]
        public ActionResult ContactEntries(ContactEntriesModel contactEntriesModel)
        {

            return CurrentTemplate(contactEntriesModel);
        }
    }
}