using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class PostReactService : BaseService
    {
        public PostReactService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public int ReactToPost(long postId, int reactId, int userId)
        {
            return ExecuteInTransaction(unit =>
            {
                var upr = new UserPostReacts()
                {
                    PostId = postId,
                    ReactId = reactId,
                    UserId = userId
                };

                unit.UsersPostsReacts.Insert(upr);
                return unit.Complete();
            });
        }

        public int ReactToPost(long postId, int reactionId)
        {
            return ReactToPost(postId, reactionId, int.Parse(CurrentUser.Id));
        }

        public int RemoveReactionFromPost(int userId, long postId)
        {
            var q = GetUserPostReact(userId, postId);

            return ExecuteInTransaction(unit =>
            {
                unit.UsersPostsReacts.Delete(q);
                return unit.Complete();
            });
        }

        public int ChangeReact(int newReactId, int userId, long postId)
        {
            var newreact = new UserPostReacts()
            {
                ReactId = newReactId,
                UserId = userId,
                PostId = postId
            };

            var oldReact = GetUserPostReact(userId, postId);

            return ExecuteInTransaction(unit =>
            {
                unit.UsersPostsReacts.Delete(oldReact);
                unit.UsersPostsReacts.Insert(newreact);

                return unit.Complete();
            });
        }

        public UserPostReacts GetUserPostReact(int userId, long postId)
        {
            return unit.UsersPostsReacts
                .Get().FirstOrDefault(upr => upr.PostId == postId && upr.UserId == userId);
        }

        public IEnumerable<UserPostReacts> GetUserPostsReacts(int userId)
        {
            return unit.UsersPostsReacts
                .Get().Where(upr => upr.UserId == userId).ToList();
        }

        public IEnumerable<UserPostReacts> ReactsOfPost(long postId)
        {
            return
                unit.UsersPostsReacts
                .Get().Where(upr => upr.PostId == postId).ToList();
        }
    }
}
