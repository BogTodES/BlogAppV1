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
                new DetailedBlogVm(blog, sections, Mapper.Map<UserInfoVm>(owner)));
        }

        public IActionResult ShowBlog(string title, int ownerId)
        {
            return View();
        }



    }
}
