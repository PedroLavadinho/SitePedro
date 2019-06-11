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
    public class ContactEntriesSurfaceController : SurfaceController
    {
        [HttpPost]
        public ActionResult ContactEntries(ContactEntriesModel contactEntriesModel)
        {
            ViewBag.contactEntriesModel = contactEntriesModel;

            if (ModelState.IsValid)
            {
                var contactEntries = Services.ContentService.Create("contactoteste", 1255, "contactEntries");
                contactEntries.SetValue("fullName", contactEntriesModel.FullName);
                contactEntries.SetValue("email", contactEntriesModel.Email);
                contactEntries.SetValue("phoneNumber", contactEntriesModel.PhoneNumber);
                contactEntries.SetValue("budgetLevel", contactEntriesModel.Budget);
                contactEntries.SetValue("requirements", contactEntriesModel.Requirements);

                Services.ContentService.Save(contactEntries);
            }

            return RedirectToCurrentUmbracoPage();
        }
    }
}