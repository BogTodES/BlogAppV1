using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppV1.ViewModels.FriendVms
{
    public class MainFriendVm
    {
        public int FriendId { get; set; }
        public string FriendUsername { get; set; }
        // public IEnumerable<Blogs> Blogs { get; set; }
        public long? FriendPhoto { get; set; }

        public MainFriendVm(UserNoPass Friend)
        {
            this.FriendId = Friend.Id;
            this.FriendUsername = Friend.Username;
            this.FriendPhoto = Friend.PhotoId;
        }
    }
}
