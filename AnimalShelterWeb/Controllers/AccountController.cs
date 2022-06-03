using Core;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace AnimalShelterWeb.Controllers
{
    public class AccountController : Controller
    {
        public User User { get; set; }
        private UserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }

        [Authorize]
        public IActionResult Index()
        {
            if (Request.Cookies["Id"] != null)
            {
                var userId = int.Parse(Request.Cookies["Id"]);
                User = _userService.GetUser(userId);
            }
            return View(User);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUser(model.Email, model.Password);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User 
                    {
                        Login = model.Email,
                        Password = model.Password 
                    };
                    _userService.SaveUser(user);

                    User = user;

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetUser(model.Email, model.Password);

                if (user != null)
                {
                    await Authenticate(user);
                    User = user;
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            Response.Cookies.Append("Id", user.Id.ToString());
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
        }
        [HttpPost]
        public IActionResult SaveUser(User user)
        {
            _userService.SaveUser(user);
            return Redirect("~/");
        }
    }
}
