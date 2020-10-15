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

        public IActionResult AddUserPhoto(IFormFile img)
        {
            var title = img.FileName;

            MemoryStream ms = new MemoryStream();
            img.CopyTo(ms);

            mediaService.AddUserPhoto(ms);

            /*ms.Close();
            ms.Dispose();*/

            return Json(new {
                flag = true
            });
        }
    }
}
