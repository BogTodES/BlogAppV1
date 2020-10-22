using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class FriendRequestsService : BaseService
    {
        // handles friendRequests



        public FriendRequestsService(UnitOfWork unit, CurrentUserDto currentUserDto) :
            base(unit, currentUserDto)
        {
        }

        public IEnumerable<FriendRequests> ReceivedFriendRequests(int userId)
        {
            return unit.FriendRequests
                .Get().Where(fr => fr.ReceiverId == userId && !fr.IsDeleted).ToList();

        }

        public IEnumerable<FriendRequests> ReceivedFriendRequests()
        {
            return ReceivedFriendRequests(int.Parse(CurrentUser.Id));
        }

        public IEnumerable<FriendRequests> SentFriendRequests(int userId)
        {
            return unit.FriendRequests
                .Get().Where(fr => fr.SenderId == userId);
        }

        public IEnumerable<FriendRequests> SentFriendRequests()
        {
            return SentFriendRequests(int.Parse(CurrentUser.Id));
        }

        public bool IsSentRequest(int senderId, int receiverId)
        {
            return unit.FriendRequests
                .Get().Any(freq => freq.SenderId == senderId && freq.ReceiverId == receiverId);
        }

        public bool IsSentRequest(int receiverId)
        {
            if(CurrentUser.IsAuthenticated)
                return IsSentRequest(int.Parse(CurrentUser.Id), receiverId);
            return false;
        }

        public int SendFriendRequest(int senderId, int receiverId)
        {
            return ExecuteInTransaction(unit =>
            {
                // o sterg pe cea veche daca exista si adaug una noua

                var oldFr = unit.FriendRequests.Get()
                    .FirstOrDefault(fr => (fr.SenderId == senderId && fr.ReceiverId == receiverId) ||
                                          (fr.SenderId == receiverId && fr.ReceiverId == senderId));

                if(oldFr != null)
                    unit.FriendRequests.Delete(oldFr);

                var newFr = new FriendRequests()
                {
                    SenderId = senderId,
                    ReceiverId = receiverId,
                    CreateDate = DateTime.Now,
                    IsDeleted = false
                };

                unit.FriendRequests.Insert(newFr);
                return unit.Complete();
            });
        }

        public int SendFriendRequest(int receiverId)
        {
            return SendFriendRequest(int.Parse(CurrentUser.Id), receiverId);
        }

        public int DeleteFriendRequest(int senderId, int receiverId)
        {
            return ExecuteInTransaction(unit =>
            {
                var delFr = unit.FriendRequests
                    .Get()
                    .FirstOrDefault(fr => (fr.SenderId == senderId && fr.ReceiverId == receiverId) ||
                                          (fr.SenderId == receiverId && fr.ReceiverId == senderId));

                unit.FriendRequests.Delete(delFr);
                return unit.Complete();
            });
        }

        public int DeleteFriendRequest(int receiverId)
        {
            return DeleteFriendRequest(int.Parse(CurrentUser.Id), receiverId);
        }

        public int HideFriendRequest(int senderId, int receiverId)
        {
            return ExecuteInTransaction(unit =>
            {
                var updFr = unit.FriendRequests
                    .Get()
                    .FirstOrDefault(fr => (fr.SenderId == senderId && fr.ReceiverId == receiverId) ||
                                          (fr.SenderId == receiverId && fr.ReceiverId == senderId));

                updFr.IsDeleted = true;
                unit.FriendRequests.Update(updFr);

                return unit.Complete();
            });
        }
    }
}
