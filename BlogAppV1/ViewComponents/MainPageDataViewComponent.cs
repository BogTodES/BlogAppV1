using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.Controllers;
using BlogAppV1.DataAccess;
using BlogAppV1.ViewModels.Home;
using BlogAppV1.ViewModels.HomeVms;
using BlogAppV1.ViewModels.PostVms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    public class MainPageDataViewComponent : ViewComponent
    {
        private readonly SearchService searchService;
        private readonly FriendsService friendsService;
        private readonly BlockService blockService;
        private readonly ReactionService reactionService;
        private readonly UserBlogService userBlogService;
        private readonly SectionsService sectionsService;
        private readonly BlogService blogService;
        private readonly UserInfoService userInfoService;

        private readonly Random randomizer;

        public MainPageDataViewComponent(SearchService searchService, FriendsService friendsService, 
            BlockService blockService, ReactionService reactionService, 
            UserBlogService userBlogService, SectionsService sectionsService,
            BlogService blogService, UserInfoService userInfoService)
        {
            this.searchService = searchService;
            this.friendsService = friendsService;
            this.blockService = blockService;
            this.reactionService = reactionService;
            this.userBlogService = userBlogService;
            this.sectionsService = sectionsService;
            this.blogService = blogService;
            this.userInfoService = userInfoService;

            this.randomizer = new Random();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var finalResults = new HomeResultsVm()
            {
                BlogResults = new List<HomeBlogVm>(),
                PostResults = new List<HomePostVm>(),
                SectionResults = new List<HomeSectionVm>()
            };


            var friends = friendsService.FriendsOf().Take(randomizer.Next(5, 10));
            foreach (var friend in friends)
            {
                var frResults = GetResultsForUser(friend);

                finalResults.BlogResults.AddRange(frResults.BlogResults);
                finalResults.PostResults.AddRange(frResults.PostResults);
                finalResults.SectionResults.AddRange(frResults.SectionResults);
            }

            var randUsers = userInfoService.GetRandomUsers(randomizer);
            foreach(var randUser in randUsers)
            {
                var uResults = GetResultsForUser(randUser);

                finalResults.BlogResults.AddRange(uResults.BlogResults);
                finalResults.PostResults.AddRange(uResults.PostResults);
                finalResults.SectionResults.AddRange(uResults.SectionResults);
            }


            return View("HomeResults", finalResults);
        }

        private HomeResultsVm GetResultsForUser(Users user)
        {
            var postResults = new List<HomePostVm>();
            var blogResults = new List<HomeBlogVm>();
            var sectResults = new List<HomeSectionVm>();

            var blogs = userBlogService.GetBlogsForUser(user.Id)
                    .OrderByDescending(b => b.Id)   // ca sa selectam din cele mai noi
                    .Take(randomizer.Next(2, 5)).ToList();
            foreach (var blog in blogs)
            {
                var sects = blogService.GetSections(blog.Id)
                    .OrderByDescending(s => s.Id)
                    .Take(randomizer.Next(3, 6));
                foreach (var sect in sects)
                {
                    var bestPosts = sectionsService.TopNPosts(sect.Id, randomizer.Next(2, 4));
                    foreach (var post in bestPosts)
                    {
                        postResults.Add(new HomePostVm()
                        {
                            PostId = post.Id,
                            PostBody = post.Body,
                            PostTitle = post.Title,
                            OwnerId = user.Id,
                            OwnerUsername = user.Username,
                            SectId = sect.Id,
                            SectTitle = sect.Name,
                            PhotoId = post.PhotoId
                        });
                    }

                    sectResults.Add(new HomeSectionVm()
                    {
                        SectId = sect.Id,
                        SectTitle = sect.Name,
                        BlogId = blog.Id,
                        OwnerId = user.Id,
                        OwnerUsername = user.Username,
                        PhotoId = sect.PhotoId
                    });
                }

                blogResults.Add(new HomeBlogVm()
                {
                    BlogId = blog.Id,
                    BlogTitle = blog.Title,
                    OwnerId = user.Id,
                    OwnerUsername = user.Username,
                    PhotoId = blog.PhotoId,
                    Sections = sects
                });
            }

            return new HomeResultsVm()
            {
                BlogResults = blogResults,
                PostResults = postResults,
                SectionResults = sectResults
            };
        }
    }
}
