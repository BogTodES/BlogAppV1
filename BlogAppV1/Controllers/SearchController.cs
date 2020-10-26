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

        public IActionResult SearchWith(string keyword)
        {
            
            var resultsList = new List<SearchResult>();

            if (keyword is null || keyword == "")
                return Json(resultsList);

            var blogResults = searchService.BlogsWithKeyword(keyword).Take(3);
            foreach(var blg in blogResults)
            {
                var owner = blogService.Owner(blg.Id);
                var newResult = new BlogSearchResult(keyword, blg, owner);
                resultsList.Add(newResult);
            }

            var userResults = searchService.UsersWithKeyword(keyword).Take(3);
            foreach (var usr in userResults)
            {
                var blogs = userBlogService.GetBlogsForUser(usr.Id);
                resultsList.Add(new UserSearchResult(keyword, new UserNoPass(usr), blogs));
            }

            var sectionResults = searchService.SectionsWithKeyword(keyword).Take(3);
            foreach(var sect in sectionResults)
            {
                var blogs = sectionsService.BlogsUsingSectId(sect.Id);
                resultsList.Add(new SectionSearchResult(keyword, sect, blogs));
            }

            return Json(resultsList);
        }
    }
}
