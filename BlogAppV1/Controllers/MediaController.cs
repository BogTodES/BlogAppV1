using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class MediaController : Controller
    {
        private readonly MediaService mediaService;

        public MediaController(MediaService mediaService)
        {
            this.mediaService = mediaService;
        }

        [HttpPost]
        public IActionResult AddUserPhoto(IFormFile img)
        {
            if(img == null)
                return RedirectToActionPermanent("ProfileOf", "UserInfo", new { username = mediaService.CurrentUser.Username });

            var title = img.FileName;

            var ms = new MemoryStream();
            img.CopyTo(ms);

            mediaService.AddUserPhoto(ms);

            return RedirectToActionPermanent("ProfileOf", "UserInfo", new { username = mediaService.CurrentUser.Username });
        }

        [HttpPost]
        public IActionResult AddSectPhoto(IFormFile img, long sectId)
        {
            if (img == null)
                return RedirectToActionPermanent("SectionDetails", "Section", new { sectId = sectId });

            var ms = new MemoryStream();
            img.CopyTo(ms);

            mediaService.AddSectPhoto(ms, sectId);

            return RedirectToActionPermanent("SectionDetails", "Section", new { sectId = sectId });
        }

        [HttpPost]
        public IActionResult AddBlogPhoto(IFormFile img, long blogId)
        {
            if (img == null)
                return RedirectToActionPermanent("ShowBlogWith", "Blog", new { blogId = blogId });

            var ms = new MemoryStream();
            img.CopyTo(ms);

            mediaService.AddBlogPhoto(ms, blogId);

            return RedirectToActionPermanent("ShowBlogWith", "Blog", new { blogId = blogId });
        }

        public FileResult GetPhoto(long photoId)
        {
            var img = mediaService.GetPhoto(photoId);
            if (img == null)
                return null;

            return File(img.Content, "image/jpeg");
        }


        public FileResult GetUserPhoto(int userId)
        {
            var img = mediaService.GetImageForUser(userId);
            if (img == null)
                return null;

            return File(img.Content, "image/jpeg");
        }

    }
}
