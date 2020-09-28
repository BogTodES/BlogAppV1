using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using BlogAppV1.BusinessLogic;
using BlogAppV1.DataAccess;
using BlogAppV1.Entities.DTOs;
using BlogAppV1.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BlogAppV1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserAccountService userAccountService;

        public AccountController(UserAccountService userServ)
        {
            userAccountService = userServ;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new SmallUserVm();
            return View("RegisterPage", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(SmallUserVm newUser)
        {
            if(ModelState.IsValid)
            {
                // la inceput este suficient sa stiu username/email si parola,
                // nu am nevoie de data nasterii, poza sau gender

                // tempNewUserVm are doar username/email si parola, 
                // dar trebuie sa trimit un User intreg in serviciu

                // datele sunt bune
                
                if(this.userAccountService.IsTaken(newUser.Email))
                    return View("RegisterPage", newUser);
                else
                {
                    var tempUser = new Users()
                    {
                        Username = newUser.Email,
                        Email = newUser.Email,
                        PasswordHash = newUser.Password
                    };

                    this.userAccountService.Register(tempUser);
                    await LogIn(tempUser);
                }
                return RedirectToAction("Index", "Home");
            }

            return View("RegisterPage", newUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new SmallUserVm();
            return View("LoginPage", model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(SmallUserVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("LoginPage", model);
            }

            var user = this.userAccountService.Login(model.Email, model.Password);
            if (user is null)
            {
                model.AreCredentialsInvalid = true;
                return View("LoginPage", model);
            }

            await LogIn(user);

            return RedirectToAction("Index", "Home");
        }

        private async Task LogIn(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
            };
            user.UsersRoles
                .ToList()
                .ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Role.Name)));

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                    scheme: "BlogAppCookies",
                    principal: principal);
        }

        public async Task<IActionResult> Logout()
        {
            await LogOut();

            return RedirectToAction("Index", "Home");
        }

        private async Task LogOut()
        {
            await HttpContext.SignOutAsync(scheme: "BlogAppCookies");
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult IsTaken(string emailOrUser)
        {
            return Json(this.userAccountService.IsTaken(emailOrUser));
        }
    }
}
