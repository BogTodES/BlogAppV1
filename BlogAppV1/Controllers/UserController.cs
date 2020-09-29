using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogAppV1.BusinessLogic;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using BlogAppV1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppV1.Controllers
{
    public class UserController : Controller
    {
        private readonly UserInfoService userInfoService;
        private readonly IMapper Mapper;

        public UserController(UserInfoService userInfo, IMapper mapper)
        {
            this.userInfoService = userInfo;
            this.Mapper = mapper;
        }

        /*[HttpGet]
        public IActionResult ProfileOf(int Id)
        {
            var user = userInfoService?.GetUserWithId(Id);
            if (user is null)
                return RedirectToAction("Index", "Home");

            var model = this.Mapper.Map<UserInfoVm>(user);

            if (CurrentUser.IsAuthenticated && int.Parse(CurrentUser.Id.Trim()) == Id)
                return View("SelfProfilePage", model);
            // daca sunt conectat si caut pagina mea, 
            // ajung pe pagina asta unde am si optiunea de update

            return View("ProfilePage", model);
        }*/

        [HttpGet]
        public IActionResult ProfileOf(string Username)
        {
            var user = userInfoService?.GetUserWithName(Username);
            if (user is null)
                return RedirectToAction("Index", "Home");

            var model = Mapper.Map<UserInfoVm>(user);

            if (userInfoService.CurrentUser.IsAuthenticated && userInfoService.CurrentUser.Username == Username)
                return View("SelfProfilePage", model);

            return View("OthersProfilePage", model);
        }

        [HttpGet]
        public IActionResult UpdateInfoPage()
        {
            return ProfileOf(userInfoService.CurrentUser.Username);
        }
        
        [HttpPost]
        public IActionResult UpdateInfo(UserInfoVm userwithNewInfo)
        {
            if(ModelState.IsValid)
            {
                var updatedUser = UpdateInformation(userwithNewInfo);
                userInfoService.UpdateUser(updatedUser);
                //return RedirectToAction("Logout", "Account");
            }

            return ProfileOf(userwithNewInfo.Username);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new PassChangeVm();
            return View("ChangePasswordPage", model);
        }

        [HttpPost]
        public IActionResult ChangePassword(PassChangeVm passChangeVm)
        {
            if(ModelState.IsValid)
            {
                var userId = int.Parse(userInfoService.CurrentUser.Id);
                if (userInfoService.CheckPassword(passChangeVm.OldPassword, userId))
                {
                    // pot sa schimb parola
                    userInfoService.ChangePassword(passChangeVm.NewPassword, userId);
                }  
            }
            return View("ChangePasswordPage", passChangeVm);
        }

        private Users UpdateInformation(UserInfoVm userwithNewInfo)
        {
            var userUpdateInfo = userInfoService.GetUserWithId(int.Parse(userInfoService.CurrentUser.Id));

            userUpdateInfo.Username = userwithNewInfo.Username;
            userUpdateInfo.Email = userwithNewInfo.Email;
            userUpdateInfo.Birthdate = userwithNewInfo.Birthdate;
            userUpdateInfo.Gender = userwithNewInfo.Gender;
            // photo ID

            return userUpdateInfo;
        }

        [HttpGet]
        public IActionResult DeleteAccount()
        {
            return View("DeleteAccountPage");
        }

        [HttpPost]
        public IActionResult AcceptDeleteAccount()
        {
            userInfoService.RemoveAccountWithId(int.Parse(userInfoService.CurrentUser.Id));

            return RedirectToAction("Index", "Home");
        }

    }
}
