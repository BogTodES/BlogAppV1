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
    public class CommReactsWidgetViewComponent : ViewComponent
    {
        private readonly CommReactService commReactService;
        private readonly ReactionService reactionService;
        private readonly UserInfoService userInfoService;

        public CommReactsWidgetViewComponent(CommReactService commReactService, 
            ReactionService reactionService, UserInfoService userInfoService)
        {
            this.commReactService = commReactService;
            this.reactionService = reactionService;
            this.userInfoService = userInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long commId)
        {
            var reactsToDisplay = new ReactsAndCommVm
            {
                TypesAndUsers = LoadCommReacts(commId),
                CommId = commId
            };

            return View("DisplayReactsComm", reactsToDisplay);
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
                    ReactId = type.Id,
                    CommId = commId
                });
            }

            return reactsToDisplay;
        }
    }
}
