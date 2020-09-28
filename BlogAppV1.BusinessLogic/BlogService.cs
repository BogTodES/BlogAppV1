using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic
{
    public class BlogService : BaseService
    {
        public BlogService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }


        public Blogs NewBlog(string title, int ownerId)
        { 
            return
                ExecuteInTransaction(unit =>
                {
                    var alCatelea = unit.Blogs.Get().Where(b => b.UserId == ownerId).Count();

                    var newBlog = new Blogs()
                    {
                        Id = ownerId * 10 + alCatelea,
                        UserId = ownerId,
                        Title = title
                    };

                    unit.Blogs.Insert(newBlog);

                    unit.Complete();

                    return newBlog;
                });
        }


    }
}
