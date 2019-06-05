using Microsoft.AspNet.Identity;
using SitePedro.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Security;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;

namespace SitePedro.Controllers
{
    public class ProfileSurfaceController : SurfaceController
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeUsername(ChangeUsernameModel changeUsernameModel)
        {
            ViewBag.changeUsernameModel = changeUsernameModel;
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var membershipUser = Membership.GetUser();
                var user = Services.MemberService.GetById((int)membershipUser.ProviderUserKey);
                var allUsernames = Services.MemberService.GetByUsername(changeUsernameModel.NewUsername);
                if ((changeUsernameModel.NewUsername == changeUsernameModel.ConfirmUsername) && (allUsernames == null))
                {
                    user.Username = changeUsernameModel.NewUsername;
                    Services.MemberService.Save(user);
                    FormsAuthentication.SetAuthCookie(changeUsernameModel.ConfirmUsername, false);
                    TempData["Success"] = "Username successfully changed.";
                    return RedirectToCurrentUmbracoPage();
                }
                else
                {
                    TempData["Error"] = "Error changing username. Username already exists or New and Confirm Username aren't the same.";
                    return RedirectToCurrentUmbracoPage();
                }
            }

            return RedirectToCurrentUmbracoPage();
        }

        // Change Password //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            ViewBag.changePasswordModel = changePasswordModel;
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var user = Membership.GetUser();
                var password = user.GetPassword();
                if ((changePasswordModel.OldPassword != changePasswordModel.NewPassword) && (password == changePasswordModel.OldPassword))
                {
                    user.ChangePassword(changePasswordModel.OldPassword, changePasswordModel.NewPassword);
                    TempData["Success"] = "Password successfully changed.";
                    return RedirectToCurrentUmbracoPage();
                }
                else
                {
                    TempData["Error"] = "Error changing password. Old password is wrong or the Old and New Password are the same.";
                }
            }
            return RedirectToCurrentUmbracoPage();
        }

        public ActionResult Personal(ProfileModel profileModel)
        {
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var membershipUser = Membership.GetUser();
                var user = Services.MemberService.GetById((int)membershipUser.ProviderUserKey);
                user.SetValue("nameAndSurname", profileModel.NameandSurname);
                user.SetValue("birthday", profileModel.Birthday);
                user.SetValue("weight", profileModel.Weight);
                user.SetValue("height", profileModel.Height);
                user.SetValue("hairColor", profileModel.HairColor);
                user.SetValue("eyeColor", profileModel.EyeColor);

                if (profileModel.ImagemParaCarregar != null)
                {
                    var newFileReference = Services.MediaService.CreateMedia(profileModel.NameandSurname, -1, "Image");
                    if (Valid(profileModel.ImagemParaCarregar))
                    {
                        newFileReference.SetValue(Services.ContentTypeBaseServices, "umbracoFile", profileModel.ImagemParaCarregar.FileName, profileModel.ImagemParaCarregar.InputStream);
                        Services.MediaService.Save(newFileReference);

                        user.SetValue("avatar", newFileReference.Id);

                    }
                    else
                    {
                        TempData["Error"] = "Image file extension invalid. Can only upload PNG, JPG and JPEG files.";
                        return RedirectToCurrentUmbracoPage();
                    }
                }

                Services.MemberService.Save(user);
            }
            TempData["Success"] = "Profile details saved.";
            return RedirectToCurrentUmbracoPage();
        }

        private bool Valid(HttpPostedFileBase imagem)
            {
                var fileInfo = new FileInfo(imagem.FileName);
                if ((new string[] { "png", "jpg", "jpeg" }).Contains(fileInfo.Extension)
                    && imagem.ContentLength < 15000)
                {
                    return true;
                }

                return false;
            }
        }
    }