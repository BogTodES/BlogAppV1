using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BlogAppV1.BusinessLogic
{
    public class SectionsService : BaseService
    {
        public SectionsService(UnitOfWork unit, 
            CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public int AddSection(string name, long blogId)
        {
            return ExecuteInTransaction(unit =>
            {
                var newSect = new Sections()
                {
                    Name = name,
                    IsSystemCreated = false
                };
                unit.Sections.Insert(newSect);

                var newBlogSect = new BlogsSections()
                {
                    BlogId = blogId,
                    Section = newSect
                };
                unit.BlogsSections.Insert(newBlogSect);

                return unit.Complete();
            });
        }

        public int RemoveSection(long sectId)
        {
            return ExecuteInTransaction(unit =>
            {
                var sect = unit.Sections.Get().FirstOrDefault(s => s.Id == sectId);
                unit.Sections.Delete(sect);

                return unit.Complete();
            });
        }

        public Sections GetSectionWithId(long Id)
        {
            return
                unit.Sections.Get().FirstOrDefault(sec => sec.Id == Id);
        }

        public IEnumerable<Posts> AllPosts(long sectId)
        {
            return
                unit.Posts.Get()
                    .Where(p => p.SectionId == sectId).ToList();
        }

        public List<Posts> TopNPosts(long sectId, int n)
        {
            // top N posts by number of reacts
            var posts = AllPosts(sectId)
                .OrderByDescending(p => p.Id)
                .Select(p => new 
                 { p, 
                   count = unit.UsersPostsReacts
                               .Get().Where(upr => upr.PostId == p.Id)
                               .Count() 
                 });
            return posts.OrderByDescending(pst => pst.count).Select(pst => pst.p).Take(n).ToList();
        }

        public IEnumerable<Blogs> BlogsUsingSectId(long sectId)
        {
            // aflu ce blog-uri folosesc sectiunea cu Id specificat

            var q = unit.BlogsSections.Get().Where(bls => bls.SectionId == sectId);

            var blogs = unit.Blogs.Get().ToList();
            var resultList = new List<Blogs>();
            foreach(var bl in q)
            {
                var blog = blogs.FirstOrDefault(b => b.Id == bl.BlogId);

                resultList.Add(blog);
            }

            return resultList;
        }

    }

}
