using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.Common;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using BlogAppV1.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BlogAppV1.BusinessLogic
{
    public class UserAccountService : BaseService
    {
        public UserAccountService(UnitOfWork unit, CurrentUserDto currentUserDto)
            : base(unit, currentUserDto)
        {
        }

        public Users Login(string userName, string password)
        {
            var q =
                unit.Users.Get()
                    .Include(user => user.UsersRoles)
                    .ThenInclude(urole => urole.Role)
                    .FirstOrDefault(ur => (ur.Username == userName) || (ur.Email == userName));

            if (q is null)
                return null;

            var saltString = unit.Salts.Get().FirstOrDefault(slt => slt.UserId == q.Id).Salt;
            var actualSalt = Convert.FromBase64String(saltString.Trim());
            if (PasswordManager.Match(password, q.PasswordHash, actualSalt))
                return q;

            return null;
        }

        public Users Register(Users newUser)
        {
            return ExecuteInTransaction(uow =>
            {
                string result = string.Empty;
                var salt = PasswordManager.HashPassword(newUser.PasswordHash, ref result);
                var role = uow.Roles.Get().FirstOrDefault(r => r.Id == (int)RoleTypes.Basic);
                newUser.PasswordHash = result;
                
                newUser.UsersRoles = new List<UsersRoles> { 
                    new UsersRoles { RoleId = (int)RoleTypes.Basic, UserId = newUser.Id, Role = role } 
                };

                newUser.Salts = new Salts()
                {
                    User = newUser,
                    Salt = Convert.ToBase64String(salt)
                };

                uow.Users.Insert(newUser);

                uow.Complete();

                return newUser;
            });
        }

        public bool IsTaken(string email)
        {
            var q = unit.Users.Get().FirstOrDefault(usr => (usr.Email == email) || (usr.Username == email));

            if (q is null)
                return false;
            return true;
        }
    }
}
