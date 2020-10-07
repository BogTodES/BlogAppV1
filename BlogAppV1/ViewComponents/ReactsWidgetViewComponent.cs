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
    // are un set de tipuri de reacts
    // plus nr de utilizari a fiecarui react
    // ar trebui sa fie independent si de post si de comment
    // pentru a nu face 2 clase pt practic aceeasi chestie

    public class ReactsWidgetViewComponent : ViewComponent
    {
        private readonly PostReactService postReactService;
        private readonly CommReactService commReactService;
        private readonly ReactionService reactionService;
        private readonly UserInfoService userInfoService;

        public ReactsWidgetViewComponent(PostReactService postReactService,
            CommReactService commReactService, ReactionService reactionService,
            UserInfoService userInfoService)
        {
            this.postReactService = postReactService;
            this.commReactService = commReactService;
            this.reactionService = reactionService;
            this.userInfoService = userInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long postId = -1, long commId = -1)
        {
            if (postId < 0 && commId < 0)
                return View();

            var reactsToDisplay = new List<ReactTypeUserVm>();
            if (postId != -1)
            {
                reactsToDisplay = LoadPostreacts(postId);
            }
            if (commId != -1)
            {
                reactsToDisplay = LoadCommReacts(commId);
            }

            return View("DisplayReacts", reactsToDisplay);
        }

        private List<ReactTypeUserVm> LoadCommReacts(long commId)
        {
            var reactsofComm = commReactService.ReactsOfComm(commId);

            var reactsToDisplay = new List<ReactTypeUserVm>();

            foreach (var react in reactsofComm)
            {
                var user = userInfoService.GetUserWithId(react.UserId);
                var type = reactionService.GetreactWithId(react.ReactId);

                reactsToDisplay.Add(new ReactTypeUserVm()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Type = type.Name,
                    ReactId = type.Id
                });
            }

            return reactsToDisplay;
        }

        private List<ReactTypeUserVm> LoadPostreacts(long postId)
        {
            var reactsOfPost = postReactService.ReactsOfPost(postId);

            var reactsToDisplay = new List<ReactTypeUserVm>();
            
            foreach(var react in reactsOfPost)
            {
                var user = userInfoService.GetUserWithId(react.UserId);
                var type = reactionService.GetreactWithId(react.ReactId);

                reactsToDisplay.Add(new ReactTypeUserVm()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Type = type.Name,
                    ReactId = type.Id
                });
            }

            return reactsToDisplay;
        }
    }
}
