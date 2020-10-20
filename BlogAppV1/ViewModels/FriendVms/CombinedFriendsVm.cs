using BlogAppV1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.FriendVms
{
    public class CombinedFriendsVm
    {
        public IEnumerable<MainFriendVm> FriendsList { get; set; }
        public IEnumerable<FriendRequestVm> ReceivedRequestsList { get; set; }
        public IEnumerable<FriendRequestVm> SentRequestsList { get; set; }
    }
}
