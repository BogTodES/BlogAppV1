using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlogAppV1.BusinessLogic.Services
{
    public class BlockService : BaseService
    {
        public BlockService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }
        
        public int GetBanSate(int userId)
        {
            var role = unit.UsersRoles.Get().FirstOrDefault(ur => ur.UserId == userId);
            if (role.RoleId == 5) return 2; // hard ban
            if (role.RoleId == 6) return 1; // soft ban
            return 0;
        }

        public Blocks UserBlockedUser(int userId1, int userId2)
        {
            // aici trebuie sa verific ambele capete
            return
                unit.Blocks.Get().FirstOrDefault(bl => (bl.SenderId == userId1 && bl.BlockedId == userId2) ||
                                                       (bl.BlockedId == userId1 && bl.SenderId == userId2));
        }

        public List<int> BlockedByUser(int userId)
        {
            return
                unit.Blocks.Get()
                    .Where(bl => bl.SenderId == userId).Select(bl => bl.BlockedId).ToList();
        }

        public List<int> BlockedByCurrent()
        {
            return BlockedByUser(int.Parse(CurrentUser.Id));
        }

        [Authorize("Basic")]
        public int BlockPersonal(int userId, int blockedId)
        {
            // userId il blocheaza pe blockedId

            return ExecuteInTransaction(unit =>
            {
                if (UserBlockedUser(userId, blockedId) == null)
                {
                    var newBlock = new Blocks()
                    {
                        SenderId = userId,
                        BlockedId = blockedId
                    };

                    unit.Blocks.Insert(newBlock);
                    return unit.Complete();
                }

                return -1;
            });
        }

        [Authorize("Basic")]
        public int BlockPersonal(int blockedId)
        {
            return BlockPersonal(int.Parse(CurrentUser.Id), blockedId);
        }

        public int UnblockPersonal(int senderId, int blockedId)
        {
            return ExecuteInTransaction(unit =>
            {
                var block = unit.Blocks.Get()
                    .FirstOrDefault(b => b.SenderId == senderId && b.BlockedId == blockedId);

                if (block == null)
                    return -1;

                unit.Blocks.Delete(block);
                return unit.Complete();
            });
        }

        public int UnblockPersonal(int blockedId)
        {
            return UnblockPersonal(int.Parse(CurrentUser.Id), blockedId);
        }

        [Authorize("Moderator")]
        public int SoftBlock(int blockedId)
        {
            return ExecuteInTransaction(unit =>
            {
                var oldRoles = unit.UsersRoles
                    .Get().Where(ur => ur.UserId == blockedId).ToList();

                foreach(var role in oldRoles)
                {
                    unit.UsersRoles.Delete(role);
                }

                unit.UsersRoles.Insert(new UsersRoles
                {
                    UserId = blockedId,
                    RoleId = 6
                });

                return unit.Complete();
            });
        }

        [Authorize("Admin")]
        public int HardBlock(int blockedId)
        {
            return ExecuteInTransaction(unit =>
            {
                var oldRoles = unit.UsersRoles
                    .Get().Where(ur => ur.UserId == blockedId).ToList();

                foreach (var role in oldRoles)
                {
                    unit.UsersRoles.Delete(role);
                }

                unit.UsersRoles.Insert(new UsersRoles
                {
                    UserId = blockedId,
                    RoleId = 5
                });

                return unit.Complete();
            });
        }

        [Authorize("Moderator")]
        public int RemoveBan(int blockedId)
        {
            return ExecuteInTransaction(unit =>
            {
                var blockRole = unit.UsersRoles
                    .Get().FirstOrDefault(ur => ur.UserId == blockedId);

                unit.UsersRoles.Delete(blockRole);

                unit.UsersRoles.Insert(new UsersRoles
                {
                    UserId = blockedId,
                    RoleId = 3
                });

                return unit.Complete();
            });
        }
    }
}
