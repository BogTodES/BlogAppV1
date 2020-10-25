using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic
{
    public class UserBlogService : BaseService
    {
        public UserBlogService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public IEnumerable<Blogs> GetBlogsForUser(int userId)
        {
            return
                unit.Blogs.Get()
                    .Where(blog => blog.UserId == userId).ToList();
        }

        public IEnumerable<Blogs> GetBlogsForUser(string username)
        {
            var userId = unit.Users.Get()
                .FirstOrDefault(usr => usr.Username == username).Id;

            return GetBlogsForUser(userId);
        }
    }
}
