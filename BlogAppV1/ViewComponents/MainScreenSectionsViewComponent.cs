using BlogAppV1.BusinessLogic;
using BlogAppV1.ViewModels.BlogStuff;
using BlogAppV1.ViewModels.SectionVms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    //[ViewComponent(Name = "smallsection")]
    public class MainScreenSectionsViewComponent : ViewComponent
    {
        // pentru o sectiune, afisez titlu si primele 5 postari

        private readonly SectionsService sectionsService;
        private readonly BlogService blogService;
        private readonly UserInfoService userInfoService;

        public MainScreenSectionsViewComponent(SectionsService sectionsService,
            BlogService blogService, UserInfoService userInfoService)
        {
            this.sectionsService = sectionsService;
            this.blogService = blogService;
            this.userInfoService = userInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long blogId, bool IsEditable)
        {
            var results = new List<DetailedSectionVm>();

            var blog = blogService.GetBlogWithId(blogId);
            var sectsIds = blogService.SectionsOfBlog(blogId);
            

            foreach(var sectId in sectsIds)
            {
                var s = sectionsService.GetSectionWithId(sectId);
                var posts = sectionsService.TopNPosts(sectId, 5);

                var result = new DetailedSectionVm()
                {
                    Name = s.Name,
                    Id = s.Id,
                    PhotoId = s.PhotoId,
                    IsSystemCreated = s.IsSystemCreated,
                    Posts = posts,
                    BlogId = blogId,
                    OwnerId = blog.UserId,
                    OwnerUsername = userInfoService.GetUserWithId(blog.UserId).Username
                };

                results.Add(result);
            }

            if (IsEditable)
            {
                return View("Editable", new MainScreenSectionRow()
                {
                    DetailedSections = results
                });
            }
            else
            {
                return View("Default", new MainScreenSectionRow()
                {
                    DetailedSections = results
                });
            }
        }
    }
}
