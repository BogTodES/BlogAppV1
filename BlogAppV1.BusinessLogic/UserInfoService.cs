using BlogAppV1.BusinessLogic.BaseServ;
using BlogAppV1.Common;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogAppV1.BusinessLogic
{
    public class UserInfoService : BaseService
    {
        public UserInfoService(UnitOfWork unit, CurrentUserDto currentUserDto) : 
            base(unit, currentUserDto)
        {
        }

        public Users GetUserWithId(int Id)
        {
            return
                unit.Users.Get().FirstOrDefault(u => u.Id == Id);
        }

        public UserNoPass GetUserWithIdSafe(int userId)
        {
            return new UserNoPass(
                unit.Users.Get()
                .FirstOrDefault(u => u.Id == userId));
        }

        public Users GetUserWithName(string userName)
        {
            return
                unit.Users.Get().FirstOrDefault(u => u.Username == userName);
        }

        public UserNoPass GetUserWithNameSafe(string userName)
        {
            return new UserNoPass(
                unit.Users.Get()
                .FirstOrDefault(u => u.Username == userName));
        }

        public Users GetUserWithEmail(string email)
        {
            return
                unit.Users.Get().FirstOrDefault(u => u.Email == email);
        }

        public UserNoPass GetUserWithEmailSafe(string email)
        {
            return new UserNoPass(
                unit.Users.Get()
                .FirstOrDefault(u => u.Email == email));
        }

        public int UpdateUser(Users userWithNewInfo)
        {
            return ExecuteInTransaction(unit =>
            {
                unit.Users.Update(userWithNewInfo);

                CurrentUser.Username = userWithNewInfo.Username;
                CurrentUser.Email = userWithNewInfo.Email;
                CurrentUser.Id = userWithNewInfo.Id.ToString();
                CurrentUser.IsAuthenticated = true;

                return unit.Complete();
            });
        }

        public bool CheckPassword(string pass, int userId)
        {
            var salts = Convert.FromBase64String(
                unit.Salts.Get().FirstOrDefault(s => s.UserId == userId).Salt);
            var user = unit.Users.Get().FirstOrDefault(u => u.Id == userId);

            return PasswordManager.Match(pass, user.PasswordHash, salts);
        }

        public int ChangePassword(string newPass, int userId)
        {
            return ExecuteInTransaction(unit =>
            {
                var user = unit.Users.Get().FirstOrDefault(u => u.Id == userId);

                string hashedPassword = string.Empty;
                var salt = PasswordManager.HashPassword(newPass, ref hashedPassword);

                user.PasswordHash = hashedPassword;
                user.Salts = new Salts()
                {
                    User = user,
                    Salt = Convert.ToBase64String(salt)
                };

                unit.Users.Update(user);

                return unit.Complete();
            });
        }

        public int RemoveAccountWithId(int Id)
        {
            return ExecuteInTransaction(unit =>
            {
                var userToDelete = unit.Users.Get().FirstOrDefault(u => u.Id == Id);

                unit.Users.Delete(userToDelete);

                return unit.Complete();
            });
        }
    }
}
