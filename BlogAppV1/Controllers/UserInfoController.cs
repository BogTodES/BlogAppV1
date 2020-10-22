using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using BlogAppV1.ViewModels;
using BlogAppV1.ViewModels.FriendVms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly UserInfoService userInfoService;
        private readonly FriendRequestsService friendRequestsService;
        private readonly FriendsService friendsService;
        private readonly BlockService blockService;
        private readonly IMapper Mapper;

        public UserInfoController(UserInfoService userInfoService, FriendRequestsService friendRequestsService, 
            FriendsService friendsService, BlockService blockService, IMapper mapper)
        {
            this.userInfoService = userInfoService;
            this.friendRequestsService = friendRequestsService;
            this.friendsService = friendsService;
            this.blockService = blockService;
            this.Mapper = mapper;
        }

        public IActionResult ProfileOf(int userId)
        {
            var user = userInfoService?.GetUserWithId(userId);
            if (user is null)
                return RedirectToActionPermanent("Index", "Home");

            var model = Mapper.Map<UserInfoVm>(user);

            model.IsBlocked = blockService
                .UserBlockedUser(int.Parse(userInfoService.CurrentUser.Id), model.Id) != null;
            if (model.IsBlocked)
                return NotFound("Could not find user :(");

            model.Birthdate = user.Birthdate;

            if (userInfoService.CurrentUser.IsAuthenticated &&
                int.Parse(userInfoService.CurrentUser.Username) == userId)
                return View("SelfProfilePage", model);

            model.FriendState = friendsService.CheckRelationshipWith(model.Id);
            model.BanState = blockService.GetBanSate(model.Id);

            return View("OthersProfilePage", model);
        }

        [HttpGet]
        public IActionResult ProfileOf(string Username)
        {
            var user = userInfoService?.GetUserWithName(Username);
            if (user is null)
                return RedirectToActionPermanent("Index", "Home");

            var model = Mapper.Map<UserInfoVm>(user);

            model.IsBlocked = blockService
                .UserBlockedUser(int.Parse(userInfoService.CurrentUser.Id), model.Id) != null;
            if (model.IsBlocked)
                return NotFound("Could not find user :(");

            model.Birthdate = user.Birthdate;

            if (userInfoService.CurrentUser.IsAuthenticated && 
                userInfoService.CurrentUser.Username == Username)
                return View("SelfProfilePage", model);

            model.FriendState = friendsService.CheckRelationshipWith(model.Id);
            model.BanState = blockService.GetBanSate(model.Id);

            return View("OthersProfilePage", model);
        }

        [HttpGet]
        public IActionResult UpdateInfoPage()
        {
            return ProfileOf(userInfoService.CurrentUser.Username);
        }
        
        [HttpPost]
        public IActionResult UpdateInfo(UserInfoVm userwithNewInfo)
        {
            if(ModelState.IsValid)
            {

                var updatedUser = UpdateInformation(userwithNewInfo);
                userInfoService.UpdateUser(updatedUser);
                //return RedirectToAction("Logout", "Account");
            }

            return RedirectToActionPermanent("ProfileOf", "UserInfo", new { username = userwithNewInfo.Username });
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new PassChangeVm();
            return View("ChangePasswordPage", model);
        }

        [HttpPost]
        public IActionResult ChangePassword(PassChangeVm passChangeVm)
        {
            if(ModelState.IsValid)
            {
                var userId = int.Parse(userInfoService.CurrentUser.Id);
                if (userInfoService.CheckPassword(passChangeVm.OldPassword, userId))
                {
                    // pot sa schimb parola
                    userInfoService.ChangePassword(passChangeVm.NewPassword, userId);
                }  
            }
            return View("ChangePasswordPage", passChangeVm);
        }

        private Users UpdateInformation(UserInfoVm userwithNewInfo)
        {
            var userUpdateInfo = userInfoService
                .GetUserWithId(int.Parse(userInfoService.CurrentUser.Id));

            userUpdateInfo.Username = userwithNewInfo.Username;
            userUpdateInfo.Email = userwithNewInfo.Email;
            userUpdateInfo.Birthdate = 
                (userwithNewInfo.Birthdate == null)? userUpdateInfo.Birthdate : userwithNewInfo.Birthdate;
            userUpdateInfo.Gender = userwithNewInfo.Gender;

            return userUpdateInfo;
        }

        [HttpGet]
        public IActionResult DeleteAccount()
        {
            return View("DeleteAccountPage");
        }

        [HttpPost]
        public IActionResult AcceptDeleteAccount()
        {
            userInfoService.RemoveAccountWithId(int.Parse(userInfoService.CurrentUser.Id));

            return RedirectToActionPermanent("Index", "Home");
        }
    }
}
