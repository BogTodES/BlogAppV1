using BlogAppV1.Common;
using System;
using System.Collections.Generic;

namespace BlogAppV1.DataAccess
{
    public partial class Users : IEntity
    {
        public Users()
        {
            Blogs = new HashSet<Blogs>();
            FriendRequestsReceiver = new HashSet<FriendRequests>();
            FriendRequestsSender = new HashSet<FriendRequests>();
            FriendsReceiver = new HashSet<Friends>();
            FriendsSender = new HashSet<Friends>();
            UserCommentReacts = new HashSet<UserCommentReacts>();
            UserPostReacts = new HashSet<UserPostReacts>();
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int Id { get; set; }
        public long? PhotoId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? Birthdate { get; set; }
        public byte? Gender { get; set; }

        public virtual Media Photo { get; set; }
        public virtual Salts Salts { get; set; }
        public virtual ICollection<Blogs> Blogs { get; set; }
        public virtual ICollection<FriendRequests> FriendRequestsReceiver { get; set; }
        public virtual ICollection<FriendRequests> FriendRequestsSender { get; set; }
        public virtual ICollection<Friends> FriendsReceiver { get; set; }
        public virtual ICollection<Friends> FriendsSender { get; set; }
        public virtual ICollection<Blocks> BlocksBlocked { get; set; }
        public virtual ICollection<Blocks> BlocksSender { get; set; }
        public virtual ICollection<UserCommentReacts> UserCommentReacts { get; set; }
        public virtual ICollection<UserPostReacts> UserPostReacts { get; set; }
        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
