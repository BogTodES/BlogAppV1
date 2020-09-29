using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using BlogAppV1.DataAccess;
using BlogAppV1.ViewModels.UserBlogVms;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class UserBlogController : Controller
    {
        private readonly UserBlogService userBlogService;

        public UserBlogController(UserBlogService userBlogService)
        {
            this.userBlogService = userBlogService;
        }
        private IActionResult RenderBlogList(BlogListVm blogList)
        {
            return View("BlogListPage", blogList);
        }

        [HttpGet]
        public IActionResult BlogsOfUId(int userId)
        {
            var list = userBlogService.GetBlogsForUser(userId);
            var owner = userBlogService.Owner(userId);

            return RenderBlogList(new BlogListVm
            {
                BlogList = list,
                UserId = userId,
                Username = owner.Username
            });
        }

        [HttpGet]
        public IActionResult BlogsOfUser(string username)
        {
            var list = userBlogService.GetBlogsForUser(username);
            var owner = userBlogService.Owner(username);

            return RenderBlogList(new BlogListVm()
            {
                BlogList = list,
                UserId = owner.Id,
                Username = username
            });
        }

        
    }
}
