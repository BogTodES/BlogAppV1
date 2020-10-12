using BlogAppV1.DataAccess.EFConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppV1.DataAccess
{
    public class UnitOfWork
    {
        private readonly BlogAppDBContext _context;

        public UnitOfWork(BlogAppDBContext context)
        {
            this._context = context;
        }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        private BaseRepository<Users> users;
        public BaseRepository<Users> Users => users ??= (new BaseRepository<Users>(_context));

        private BaseRepository<Blogs> blogs;
        public BaseRepository<Blogs> Blogs => blogs ??= (new BaseRepository<Blogs>(_context));

        private BaseRepository<Sections> sections;
        public BaseRepository<Sections> Sections => sections ??= (new BaseRepository<Sections>(_context));

        private BaseRepository<BlogsSections> blogsSections;
        public BaseRepository<BlogsSections> BlogsSections => blogsSections ??= (new BaseRepository<BlogsSections>(_context));

        private BaseRepository<Posts> posts;
        public BaseRepository<Posts> Posts => posts ??= (new BaseRepository<Posts>(_context));

        private BaseRepository<Comments> comments;
        public BaseRepository<Comments> Comments => comments ??= (new BaseRepository<Comments>(_context));

        private BaseRepository<Media> media;
        public BaseRepository<Media> Media => media ??= (new BaseRepository<Media>(_context));

        private BaseRepository<FriendRequests> frequests;
        public BaseRepository<FriendRequests> FriendRequests => frequests ??= (new BaseRepository<FriendRequests>(_context));

        private BaseRepository<Friends> friends;
        public BaseRepository<Friends> Friends => friends ??= (new BaseRepository<Friends>(_context));

        private BaseRepository<ReactTypes> reactTypes;
        public BaseRepository<ReactTypes> ReactTypes => reactTypes ??= (new BaseRepository<ReactTypes>(_context));

        private BaseRepository<UserCommentReacts> userCommentReacts;
        public BaseRepository<UserCommentReacts> UsersCommentsReacts => userCommentReacts ??= (new BaseRepository<UserCommentReacts>(_context));

        private BaseRepository<UserPostReacts> userPostReacts;
        public BaseRepository<UserPostReacts> UsersPostsReacts => userPostReacts ??= (new BaseRepository<UserPostReacts>(_context));


        private BaseRepository<Salts> salts;
        public BaseRepository<Salts> Salts => salts ??= (new BaseRepository<Salts>(_context));

        private BaseRepository<Roles> roles;
        public BaseRepository<Roles> Roles => roles ??= (new BaseRepository<Roles>(_context));

        private BaseRepository<Permissions> permissions;
        public BaseRepository<Permissions> Permissions => permissions ??= (new BaseRepository<Permissions>(_context));

        private BaseRepository<RolesPermissions> rolesPermissions;
        public BaseRepository<RolesPermissions> RolesPermissions => rolesPermissions ??= (new BaseRepository<RolesPermissions>(_context));

        private BaseRepository<UsersRoles> usersRoles;
        public BaseRepository<UsersRoles> UsersRoles => usersRoles ??= (new BaseRepository<UsersRoles>(_context));
    }
}
