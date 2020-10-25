using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.ViewModels;
using BlogAppV1.ViewModels.ReactsVms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    public class PostReactsWidgetViewComponent : ViewComponent
    {
        private readonly PostReactService postReactService;
        private readonly ReactionService reactionService;
        private readonly UserInfoService userInfoService;

        public PostReactsWidgetViewComponent(PostReactService postReactService, 
            ReactionService reactionService, UserInfoService userInfoService)
        {
            this.postReactService = postReactService;
            this.reactionService = reactionService;
            this.userInfoService = userInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long postId, bool IsDetailed)
        {
            var reactsToDisplay = new ReactsAndPostVm
            {
                TypesAndUsers = LoadPostreacts(postId),
                PostId = postId,
                IsDetailed = IsDetailed
            };

            return View("DisplayReactsPost", reactsToDisplay);
        }

        private List<ReactTypeUserVm> LoadPostreacts(long postId)
        {
            var reactsOfPost = postReactService.ReactsOfPost(postId);

            var reactsToDisplay = new List<ReactTypeUserVm>();

            foreach (var react in reactsOfPost)
            {
                var user = userInfoService.GetUserWithId(react.UserId);
                var type = reactionService.GetreactWithId(react.ReactId);

                reactsToDisplay.Add(new ReactTypeUserVm()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Type = type.Name,
                    ReactId = type.Id,
                    PostId = postId
                });
            }

            return reactsToDisplay;
        }
    }
}