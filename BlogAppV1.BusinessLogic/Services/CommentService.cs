using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic
{
    public class CommentService : BaseService
    {
        public CommentService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public int AddComment(string body, long postId)
        {
            return ExecuteInTransaction(unit =>
            {
                var newComm = new Comments()
                {
                    Body = body,
                    PostId = postId,
                    Date = DateTime.Now,
                    UserId = int.Parse(CurrentUser.Id)
                        // daca se adauga un comentariu, mereu va fi din partea userului curent
                };

                unit.Comments.Insert(newComm);
                return unit.Complete();
            });
        }

        public int RemoveComment(long commId)
        {
            var comm = unit.Comments.Get().FirstOrDefault(comm => comm.Id == commId);

            return ExecuteInTransaction(unit =>
            {
                unit.Comments.Delete(comm);
                return unit.Complete();
            });
        }
    }
}
