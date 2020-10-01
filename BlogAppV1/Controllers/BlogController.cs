using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAppV1.BusinessLogic;
using BlogAppV1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService blogService;
        private readonly IMapper Mapper;

        public BlogController(BlogService blogService, IMapper mapper)
        {
            this.blogService = blogService;
            this.Mapper = mapper;
        }

        public IActionResult ShowBlogWith(long id)
        {
            var blog = blogService.GetBlogWithId(id);
            var sections = blogService.SectionsOfBlog(id);
            var owner = blogService.OwnerOfBlog(blog.UserId);

            return View("DetailedBlogPage",
                new DetailedBlogVm()
                {
                    BlogId = blog.Id,
                    Title = blog.Title,
                    SectionsIds = sections,
                    OwnerUsername = owner.Username,
                    OwnerEmail = owner.Email,
                    OwnerId = owner.Id
                });
        }

        public IActionResult ShowBlog(string title, int ownerId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditBlogId(long Id)
        {
            var blog = blogService.GetBlogWithId(Id);
            var sections = blogService.SectionsOfBlog(Id);
            var owner = blogService.OwnerOfBlog(blog.UserId);

            return View("EditableBlogPage",
                new DetailedBlogVm()
                {
                    BlogId = blog.Id,
                    Title = blog.Title,
                    SectionsIds = sections,
                    OwnerUsername = owner.Username,
                    OwnerEmail = owner.Email,
                    OwnerId = owner.Id
                });
        }

        [HttpGet]
        public IActionResult EditBlog(DetailedBlogVm detailedBlogVm)
        {
            return View("EditableBlogPage", detailedBlogVm);
        }

        [HttpPost]
        public IActionResult AddBlog()
        {
            var newBlog =
                blogService.AddBlog("New Blog", int.Parse(blogService.CurrentUser.Id));

            var sections = blogService.SectionsOfBlog(newBlog.Id);
            var owner = blogService.OwnerOfBlog(newBlog.UserId);

            return EditBlog(
                new DetailedBlogVm()
                {
                    BlogId = newBlog.Id,
                    Title = newBlog.Title,
                    SectionsIds = sections,
                    OwnerUsername = owner.Username,
                    OwnerEmail = owner.Email,
                    OwnerId = owner.Id
                });
        }

        [HttpPost]
        public IActionResult DeleteBlog(long blogId)
        {
            blogService.DeleteBlog(blogId);

            // reafisez pe cele inca existente
            return RedirectToAction("BlogsOfUser", "UserBlog",
                new { username = blogService.CurrentUser.Username });
        }

        public IActionResult UpdateTitle(string newTitle, long blogId)
        {
            blogService.UpdateTitle(newTitle, blogId);

            return RedirectToAction("ShowBlogWith", "Blog", new { id = blogId });
        }
    }
}
