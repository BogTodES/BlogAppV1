using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using BlogAppV1.ViewModels.BlogStuff;
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
            this.sectionsService.AddSection(name, blogId);

            return RedirectToAction("ShowBlogWith", "Blog", new { id = blogId });
        }

        public IActionResult SectionDetails(long sectId)
        {
            // afisez postarile,
            var posts = sectionsService.AllPosts(sectId).ToList();
            var section = sectionsService.GetSectionWithId(sectId);

            return View("SectionDetails", new SmallSectionVm()
            {
                Id = sectId,
                BlogId = -1,
                Title = section.Name,
                Posts = posts
            });
        }
    }
}
