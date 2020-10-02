using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAppV1.BusinessLogic;
using BlogAppV1.DataAccess;
using BlogAppV1.ViewModels;
using BlogAppV1.ViewModels.UserBlogVms;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class UserBlogController : Controller
    {
        private readonly UserBlogService userBlogService;
        private readonly UserInfoService userInfoService;
        private readonly IMapper mapper;

        public UserBlogController(UserBlogService userBlogService, 
            UserInfoService userInfoService, IMapper mapper)
        {
            this.userBlogService = userBlogService;
            this.userInfoService = userInfoService;
            this.mapper = mapper;
        }

        private IActionResult RenderBlogList(BlogListVm blogList)
        {
            return View("BlogListPage", blogList);
        }

        [HttpGet]
        public IActionResult BlogsOfUId(int userId)
        {
            var list = userBlogService.GetBlogsForUser(userId);
            var user = userInfoService.GetUserWithIdSafe(userId);

            return RenderBlogList(new BlogListVm
            {
                BlogList = list,
                UserId = userId,
                Username = user.Username
            });
        }

        [HttpGet]
        public IActionResult BlogsOfUser(string username)
        {
            var list = userBlogService.GetBlogsForUser(username);
            var user = userInfoService.GetUserWithNameSafe(username);

            return RenderBlogList(new BlogListVm()
            {
                BlogList = list,
                UserId = user.Id,
                Username = username
            });
        }

        [HttpPost]
        public IActionResult AddSections(IEnumerable<string> namesList, int blogId)
        {
            return 
                RedirectToAction("AddSection", "Section", new { names = namesList, blogId });
        }
    }
}
