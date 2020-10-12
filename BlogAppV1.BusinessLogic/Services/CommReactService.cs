using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class CommReactService : BaseService
    {
        public CommReactService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }
        
        public int ReactToComm(int userId, long commId, int reactId)
        {
            RemoveReactionFromComm(commId, userId);

            return ExecuteInTransaction(unit =>
            {
                var ucr = new UserCommentReacts()
                {
                    CommentId = commId,
                    UserId = userId,
                    ReactId = reactId
                };

                unit.UsersCommentsReacts.Insert(ucr);
                return unit.Complete();
            });
        }

        public int ReactToComm(long commId, int reactId)
        {
            return ReactToComm(int.Parse(CurrentUser.Id), commId, reactId);
        }

        public int RemoveReactionFromComm(long commId, int userId)
        {
            var q = unit.UsersCommentsReacts
                .Get().FirstOrDefault(ucr => ucr.CommentId == commId && ucr.UserId == userId);

            return ExecuteInTransaction(unit =>
            {
                if(!(q is null))
                    unit.UsersCommentsReacts.Delete(q);

                return unit.Complete();
            });
        }

        public int RemoveReactionFromComm(long commId)
        {
            return RemoveReactionFromComm(commId, int.Parse(CurrentUser.Id));
        }

        public int ChangeReact(int newReactId, int userId, long commId)
        {
            var newreact = new UserCommentReacts()
            {
                ReactId = newReactId,
                UserId = userId,
                CommentId = commId
            };

            var oldReact = GetUserCommReact(userId, commId);

            return ExecuteInTransaction(unit =>
            {
                unit.UsersCommentsReacts.Delete(oldReact);
                unit.UsersCommentsReacts.Insert(newreact);

                return unit.Complete();
            });
        }

        public UserCommentReacts GetUserCommReact(int userId, long commId)
        {
            return unit.UsersCommentsReacts
                .Get().FirstOrDefault(upr => upr.CommentId == commId && upr.UserId == userId);
        }

        public IEnumerable<UserCommentReacts> GetUserCommReact(int userId)
        {
            return unit.UsersCommentsReacts
                .Get().Where(upr => upr.UserId == userId).ToList();
        }


        public IEnumerable<UserCommentReacts> ReactsOfComm(long commId)
        {
            return
                unit.UsersCommentsReacts
                .Get().Where(ucr => ucr.CommentId == commId).ToList();
        }
    }
}
