using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic
{
    public class PostService : BaseService
    {
        public PostService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public int AddPost(string title, string body, long sectId)
        {
            return ExecuteInTransaction(unit =>
            {
                var newPost = new Posts()
                {
                    SectionId = sectId,
                    Title = title,
                    Body = body
                };

                unit.Posts.Insert(newPost);
                return unit.Complete();
            });
        }

        public int DeletePost(long postId)
        {
            var post = unit.Posts.Get().FirstOrDefault(pst => pst.Id == postId);

            return ExecuteInTransaction(unit =>
            {
                unit.Posts.Delete(post);
                return unit.Complete();
            });
        }

        public Posts PostWithId(long postId)
        {
            return
                unit.Posts.Get().FirstOrDefault(p => p.Id == postId);
        }

        public IEnumerable<Comments> CommentsOfPost(long postId)
        {
            return
                unit.Comments.Get().Where(comm => comm.PostId == postId);
        }
    }
}
