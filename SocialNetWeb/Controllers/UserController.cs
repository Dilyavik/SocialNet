using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetData;
using SocialNetServices.Interfaces;
using SocialNetServices.Models;
using SocialNetServices.Services;
using SocialNetWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _db;
        public IUserService _userService;

        public UserController(DataContext db)
        {
            _db = db;
            _userService = new UserService(_db);
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            return View();
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationRequest request)
        {
            await _userService.Registration(new UserRegistrationRequest()
            {
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                Login = request.Login,
                Password = request.Password
            });

            return Content("Регистрация прошла успешно");
        }


        /// <summary>
        /// Авторизация
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(Models.LoginRequest request)
        {
            var userId = await _userService.Login(new SocialNetServices.Models.LoginRequest()
            {
                Login = request.Login,
                Password = request.Password
            });
            HttpContext.Session.SetInt32("UserId", userId);

            return Content("Пользователь авторизован");
        }

        /// <summary>
        /// Профиль пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var result = await _userService.GetUser(userId.Value);
            var user = new UserResponse()
            {
                FirstName = result.FirstName,
                SecondName = result.SecondName
            };

            return View(user);
        }
    }
}
