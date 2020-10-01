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
        
        public Blogs GetBlogWithId(long Id)
        {
            return
                unit.Blogs.Get().FirstOrDefault(bl => bl.Id == Id);
        }

        public Blogs AddBlog(string title, int ownerId)
        { 
            return
                ExecuteInTransaction(unit =>
                {
                    var alCatelea = unit.Blogs.Get()
                        .Where(b => b.UserId == ownerId).Count() + 1;

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

        public int DeleteBlog(long Id)
        {
            return
                ExecuteInTransaction(unit =>
                {
                    unit.Blogs.Delete(GetBlogWithId(Id));
                    return unit.Complete();
                });
        }

        public IEnumerable<long> SectionsOfBlog(long Id)
        {
            return
                unit.BlogsSections
                    .Get().Where(bs => bs.BlogId == Id)
                    .Select(bs => bs.SectionId).ToList();
        }
     
        public UserNoPass OwnerOfBlog(int ownerId)
        {
            return new UserNoPass(
                unit.Users.Get()
                .FirstOrDefault(usr => usr.Id == ownerId));
        }

        public int UpdateTitle(string newTitle, long blogId)
        {
            newTitle = newTitle.Trim();
            var blog = unit.Blogs.Get().FirstOrDefault(bl => bl.Id == blogId);
            blog.Title = newTitle;

            return ExecuteInTransaction(unit =>
            {
                unit.Blogs.Update(blog);
                return unit.Complete();
            });
        }
    }
}
