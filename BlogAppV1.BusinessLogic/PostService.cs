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

        public IEnumerable<CommentInfoDto> CommentsOfPost(long postId)
        {
            var q = 
                unit.Comments.Get().Where(comm => comm.PostId == postId).ToList();

            var result = new List<CommentInfoDto>();
            foreach(var comm in q)
            {
                result.Add(new CommentInfoDto()
                {
                    Id = comm.Id,
                    PostId = postId,
                    Body = comm.Body,
                    ElapsedTime = (DateTime.Now - comm.Date),
                    Reacts = comm.UserCommentReacts,
                    CommenterId = comm.UserId,
                });
            }

            return result;
        }

        public PosterDto GetPosterInfo(long postId)
        {
            var user = unit.Users.Get()
                .Join(unit.Blogs.Get(),
                      usr => usr.Id,
                      blg => blg.UserId,
                      (usr, blg) => new { UsrId = usr.Id, UsrName = usr.Username, Blg = blg.Id })
                .Join(unit.BlogsSections.Get(),
                      usrAndBlg => usrAndBlg.Blg,
                      blgSect => blgSect.BlogId,
                      (usrAndBlg, blgSect) => new { UsrId = usrAndBlg.UsrId, UsrName = usrAndBlg.UsrName, SectId = blgSect.SectionId })
                .Join(unit.Posts.Get(),
                      usrAndSect => usrAndSect.SectId,
                      post => post.SectionId,
                      (usrAndSect, post) => new { UsrId = usrAndSect.UsrId, UsrName = usrAndSect.UsrName, PostId = post.Id })
                .FirstOrDefault(usrAndPost => usrAndPost.PostId == postId);

            return new PosterDto()
            {
                PosterUsername = user.UsrName,
                PosterId = user.UsrId,
                PostId = user.PostId
            };
        }
    }
}
