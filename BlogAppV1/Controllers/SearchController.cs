using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.Entities.DTOs;
using BlogAppV1.ViewModels.SearchVms;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class SearchController : Controller
    {
        private readonly UserInfoService userInfoService;
        private readonly BlogService blogService;
        private readonly SectionsService sectionsService;
        private readonly SearchService searchService;
        private readonly UserBlogService userBlogService;

        public SearchController(UserInfoService userInfoService, 
            BlogService blogService, SectionsService sectionsService, 
            SearchService searchService, UserBlogService userBlogService)
        {
            this.userInfoService = userInfoService;
            this.blogService = blogService;
            this.sectionsService = sectionsService;
            this.searchService = searchService;
            this.userBlogService = userBlogService;
        }

        [HttpGet]
        public IActionResult SearchWith(string keyword)
        {
            var resultsList = new List<SearchResult>();

            var blogResults = searchService.BlogsWithKeyword(keyword);
            foreach(var blg in blogResults)
            {
                var owner = blogService.Owner(blg.Id);
                resultsList.Add(new BlogSearchResult(keyword, blg, owner));
            }

            var userResults = searchService.UsersWithKeyword(keyword);
            foreach (var usr in userResults)
            {
                var blogs = userBlogService.GetBlogsForUser(usr.Id);
                resultsList.Add(new UserSearchResult(keyword, new UserNoPass(usr), blogs));
            }

            var sectionResults = searchService.SectionsWithKeyword(keyword);
            foreach(var sect in sectionResults)
            {
                var blogs = sectionsService.BlogsUsingSectId(sect.Id);
                resultsList.Add(new SectionSearchResult(keyword, sect, blogs));
            }

            return Json(resultsList);
        }
    }
}
