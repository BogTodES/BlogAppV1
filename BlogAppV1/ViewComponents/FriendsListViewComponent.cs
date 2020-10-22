using BlogAppV1.BusinessLogic;
using BlogAppV1.BusinessLogic.Services;
using BlogAppV1.Entities.DTOs;
using BlogAppV1.ViewModels.FriendVms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewComponents
{
    public class FriendsListViewComponent : ViewComponent
    {
        private readonly UserInfoService userInfoService;
        private readonly FriendsService friendsService;
        private readonly FriendRequestsService friendRequestsService;

        public FriendsListViewComponent(FriendRequestsService friendRequestsService, 
            FriendsService friendsService, UserInfoService userInfoService)
        {
            this.friendsService = friendsService;
            this.friendRequestsService = friendRequestsService;
            this.userInfoService = userInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sentRequests = new List<FriendRequestVm>();
            var receivedRequests = new List<FriendRequestVm>();

            var friends = friendsService.FriendsOf()
                .Select(f => new MainFriendVm(new UserNoPass(f)));
            friendRequestsService
                .ReceivedFriendRequests()
                .ToList()
                .ForEach(rReq => {
                    var s = userInfoService.GetUserWithId(rReq.SenderId);
                    receivedRequests.Add(new FriendRequestVm()
                    {
                        SenderUsername = s.Username,
                        SenderId = s.Id,
                        SenderPhoto = s.Photo,
                        Date = rReq.CreateDate,
                        IsDeleted = rReq.IsDeleted
                    });
                });

            return View("FriendsListFloater", 
                new CombinedFriendsVm()
                {
                    FriendsList = friends,
                    SentRequestsList = sentRequests,
                    ReceivedRequestsList = receivedRequests
                });
        }
    }
}
