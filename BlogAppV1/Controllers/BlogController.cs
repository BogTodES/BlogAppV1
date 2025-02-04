﻿using System;
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
        private readonly UserInfoService userInfoService;
        private readonly IMapper Mapper;

        public BlogController(BlogService blogService, UserInfoService userInfoService, IMapper mapper)
        {
            this.blogService = blogService;
            this.userInfoService = userInfoService;
            this.Mapper = mapper;
        }

        public IActionResult ShowBlogWith(long blogId)
        {
            var blog = blogService.GetBlogWithId(blogId);
            if(blog == null)
            {
                return NotFound("This blog does not exist or it is inaccessible");
            }

            var sections = blogService.SectionsOfBlog(blogId);
            var owner = userInfoService.GetUserWithId(blog.UserId);

            return View("DetailedBlogPage",
                new DetailedBlogVm()
                {
                    BlogId = blog.Id,
                    Title = blog.Title,
                    SectionsIds = sections,
                    PhotoId = blog.PhotoId,
                    OwnerUsername = owner.Username,
                    OwnerEmail = owner.Email,
                    OwnerId = owner.Id
                });
        }
        
        public IActionResult EditBlogId(long blogId)
        {
            var blog = blogService.GetBlogWithId(blogId);
            var sections = blogService.SectionsOfBlog(blogId);
            var owner = userInfoService.GetUserWithIdSafe(blog.UserId);

            return View("EditableBlogPage",
                new DetailedBlogVm()
                {
                    BlogId = blog.Id,
                    Title = blog.Title,
                    SectionsIds = sections,
                    PhotoId = blog.PhotoId,
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
            var owner = userInfoService.GetUserWithIdSafe(newBlog.UserId);

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

        /*[HttpPost]*/
        public IActionResult DeleteBlog(long blogId)
        {
            blogService.DeleteBlog(blogId);

            // reafisez pe cele inca existente
            return RedirectToAction("ShowBlogWith", "Blog",
                new { blogId = blogId });
        }

        public IActionResult UpdateTitle(string newTitle, long blogId)
        {
            blogService.UpdateTitle(newTitle, blogId);

            return RedirectToActionPermanent("ShowBlogWith", "Blog", new { blogId = blogId });
        }
    }
}
