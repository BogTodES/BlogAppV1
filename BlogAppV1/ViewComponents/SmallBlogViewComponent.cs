using BlogAppV1.BusinessLogic;
using BlogAppV1.DataAccess;
using BlogAppV1.ViewModels.BlogStuff;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    public class SmallBlogViewComponent : ViewComponent
    {
        private readonly BlogService blogService;
        private readonly SectionsService sectionsService;
        private readonly PostService postService;

        public SmallBlogViewComponent(BlogService blogService, 
            SectionsService sectionsService, PostService postService)
        {
            this.blogService = blogService;
            this.sectionsService = sectionsService;
            this.postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long blogId)
        {
            var sectionRow = new List<SmallSectionVm>();
            var sectionIds = blogService.SectionsOfBlog(blogId);
            foreach(var sectId in sectionIds)
            {
                var sect = sectionsService.GetSectionWithId(sectId);
                sectionRow.Add(new SmallSectionVm()
                {
                    Id = sectId,
                    Title = sect.Name,
                    PhotoId = sect.PhotoId,
                    BlogId = blogId,
                    Posts = await FillPosts(sectId)
                });
            }

            return View("SectionRow", sectionRow);
        }

        private async Task<IEnumerable<Posts>> FillPosts(long sectId)
        {
            var topPosts = sectionsService.TopNPosts(sectId, 3);
            return topPosts;
        }
    }
}
