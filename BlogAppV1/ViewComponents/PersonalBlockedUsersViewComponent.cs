using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    public class PersonalBlockedUsersViewComponent : ViewComponent
    {
        private readonly BlockService blockService;
        private readonly UserInfoService userInfoService;


        public PersonalBlockedUsersViewComponent(BlockService blockService, 
            UserInfoService userInfoService)
        {
            this.blockService = blockService;
            this.userInfoService = userInfoService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blockedIds = blockService.BlockedByCurrent();
            var blockedUsers = blockedIds
                .Select(uid => new UserNoPass(userInfoService.GetUserWithId(uid))).ToList();


            return View("PersonalBlockedList", blockedUsers);
        }

    }
}
