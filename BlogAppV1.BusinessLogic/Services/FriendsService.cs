using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class FriendsService : BaseService
    {
        private readonly FriendRequestsService friendRequestsService;

        public FriendsService(UnitOfWork unit, CurrentUserDto currentUserDto, 
            FriendRequestsService friendRequestsService) :
            base(unit, currentUserDto)
        {
            this.friendRequestsService = friendRequestsService;
        }

        public List<Users> FriendsOf(int userId)
        {
            var friends = unit.Friends
                .Get().Where(f => f.SenderId == userId || f.ReceiverId == userId);
                // o prietenie este bidirectionala, de asta trebuie sa verific ambii participanti
            var users = unit.Users
                .Get().ToList();

            var retList = new List<Users>();
            foreach(var f in friends)
            {
                retList
                    .Add(users.FirstOrDefault(u => u.Id == f.SenderId || u.Id == f.ReceiverId));
            }

            return retList;
        }

        public List<Users> FriendsOf()
        {
            // current user
            return FriendsOf(int.Parse(CurrentUser.Id));
        }

        public Friends AreFriends(int userId1, int userId2)
        {
            // returnez obiect de friend sau null

            return unit.Friends
                .Get().FirstOrDefault(fr => 
                        (fr.SenderId == userId1 && fr.ReceiverId == userId2) || 
                        (fr.SenderId == userId2 && fr.ReceiverId == userId1) );
        }

        public bool IsFriend(int receiverId)
        {
            // daca am null in expresia de mai jos, inseamna ca nu exista prietenie
            return (AreFriends(int.Parse(CurrentUser.Id), receiverId) != null);
        }

        public int MakeFriend(int userId1, int userId2)
        {
            return ExecuteInTransaction(unit =>
            {
                if (AreFriends(userId1, userId2) != null)
                    return -1;

                var newFriendship = new Friends()
                {
                    SenderId = userId1,
                    ReceiverId = userId2,
                    CreateDate = DateTime.Now
                };

                unit.Friends.Insert(newFriendship);
                return unit.Complete();
            });
        }

        public int Unfriend(int userId1, int userId2)
        {
            return ExecuteInTransaction(unit =>
            {
                var friendship = AreFriends(userId1, userId2);

                if (friendship is null)
                    return -1;
                // daca nu sunt prieteni din start dar am ajuns sa apelez functia, ceva e gresit

                unit.Friends.Delete(friendship);
                return unit.Complete();
            });
        }

        public int Unfriend(int unfriendId)
        {
            return Unfriend(int.Parse(CurrentUser.Id), unfriendId);
        }

        public int CheckRelationshipWith(int userId)
        {
            if (IsFriend(userId))
                return 3;   // suntem prieteni deja

            var sReq = friendRequestsService.IsSentRequest(userId);
            var rReq = friendRequestsService.IsSentRequest(userId, int.Parse(CurrentUser.Id));

            if (sReq) return 1; // eu am trimis si astept
            if (rReq) return 2; // el a trimis

            return 0; // nu a fost facuta nicio actiune de prietenie
        }
    }
}
