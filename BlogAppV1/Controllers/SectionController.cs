﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using BlogAppV1.ViewModels;
using BlogAppV1.ViewModels.BlogStuff;
using BlogAppV1.ViewModels.SectionVms;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class SectionController : Controller
    {
        private readonly SectionsService sectionsService;

        public SectionController(SectionsService sectionsService)
        {
            this.sectionsService = sectionsService;
        }

        //[HttpPost]
        /*public IActionResult AddSection(IEnumerable<string> names, long blogId)
        {
            foreach(var newName in names)
            {
                this.sectionsService.AddSection(newName, blogId);
            }

            return RedirectToAction("ShowBlogWith", "Blog", new { id = blogId });
        }*/

        [HttpPost]
        public IActionResult AddSection(string name, long blogId)
        {
            sectionsService.AddSection(name, blogId);

            return RedirectToActionPermanent("Index", "Home", new { blogId = blogId });
        }

        public IActionResult RemoveSection(long sectId)
        {
            sectionsService.RemoveSection(sectId);

            return Json(new
            {
                flag = true
            }); ;
        }

        public IActionResult SectionDetails(long sectId)
        {
            var section = sectionsService.GetSectionWithId(sectId);
            if (section is null)
                return NotFound("The Section you are looking for has been deleted or is unaccessible");

            var posts = sectionsService.AllPosts(sectId).ToList();
            var blogs = sectionsService.BlogsUsingSectId(sectId);

            return View("SectionDetails", new DetailedSectionVm()
            {
                Id = sectId,
                BlogId = (section.IsSystemCreated)? -1 : blogs.FirstOrDefault().Id, 
                    // daca nu este systemCreated, tin minte la ce blog apartine cand afisez sectiunea
                OwnerId = (section.IsSystemCreated) ? -1 : blogs.FirstOrDefault().UserId,
                Name = section.Name,
                Posts = posts,
                PhotoId = section.PhotoId,
                IsSystemCreated = section.IsSystemCreated
            });
        }
    }
}
