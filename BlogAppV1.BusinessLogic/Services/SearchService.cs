using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class SearchService : BaseService
    {

        public SearchService(UnitOfWork unit, CurrentUserDto currentUserDto) 
            : base(unit, currentUserDto)
        { 
        }

        public List<Blogs> BlogsWithKeyword(string Keyword)
        {
            var resultList = new List<Blogs>();
            var blogs = unit.Blogs.Get().ToList();

            foreach(var blog in blogs)
            {
                if (blog.Title.ToLower().Contains(Keyword.ToLower()))
                    resultList.Add(blog);
            }

            return resultList;
        }

        public List<Users> UsersWithKeyword(string keyword)
        {
            var resultList = new List<Users>();
            var users = unit.Users.Get().ToList();

            foreach(var user in users)
            {
                if (user.Username.ToLower().Contains(keyword.ToLower()))
                    resultList.Add(user);
                else if (user.Email.ToLower().Contains(keyword.ToLower()))
                    resultList.Add(user);
            }

            return resultList;
        }

        public List<Sections> SectionsWithKeyword(string keyword)
        {
            var resultList = new List<Sections>();
            var sections = unit.Sections.Get().ToList();

            foreach (var sect in sections)
            {
                if (sect.Name.ToLower().Contains(keyword.ToLower()))
                    resultList.Add(sect);
            }

            return resultList;
        }

    }
}
