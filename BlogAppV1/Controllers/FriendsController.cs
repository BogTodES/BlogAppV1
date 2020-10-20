using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.Entities.DTOs;
using BlogAppV1.ViewModels;
using BlogAppV1.ViewModels.FriendVms;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class FriendsController : Controller
    {
        private readonly FriendsService friendsService;
        private readonly FriendRequestsService friendRequestsService;
        private readonly UserBlogService userBlogService;

        public FriendsController(FriendsService friendsService, 
            FriendRequestsService friendRequestsService, UserBlogService userBlogService)
        {
            this.friendsService = friendsService;
            this.friendRequestsService = friendRequestsService;
            this.userBlogService = userBlogService;
        }

        public IActionResult MainFriendsList(int userId)
        {
            var friendsList = new List<UserInfoVm>();

            friendsService
                .FriendsOf(userId)
                .ForEach(usr => friendsList
                    .Add(new UserInfoVm()
                    {
                        Id = usr.Id,
                        Username = usr.Username,
                        Email = usr.Email,
                        Photo = usr.Photo,
                        Gender = usr.Gender
                    })
                 );

            return View("MainFriendsList", friendsList);
        }

        public IActionResult Unfriend(int unfriendId)
        {
            var x = friendsService.Unfriend(unfriendId);

            var flag = (x >= 0) ? true : false;

            return Json(new
            {
                flag = flag
            });
        }

        public IActionResult SendFrRequest(int toUserId)
        {
            var rows = friendRequestsService.SendFriendRequest(toUserId);

            return Json(new
            {
                flag = (rows >= 0) ? true : false
            });
        }

        public IActionResult AcceptFrRequestFrom(int senderId)
        {
            var rows1 = friendRequestsService
                .DeleteFriendRequest(senderId, int.Parse(friendsService.CurrentUser.Id));

            var rows2 = friendsService.MakeFriend(senderId);

            return Json(new
            {
                flag = ((rows1 + rows2) >= 1) ? true : false
            });
        }

        public IActionResult DeclineRequest(int senderId)
        {
            var rows = friendRequestsService
                .HideFriendRequest(senderId, int.Parse(friendsService.CurrentUser.Id));

            return Json(new
            {
                flag = true
            });
        }

        public IActionResult RemoveRequest(int receiverId)
        {
            var rows = friendRequestsService.DeleteFriendRequest(receiverId);

            return Json(new 
            {
                flag = (rows >= 0)
            });
        }
    }
}
