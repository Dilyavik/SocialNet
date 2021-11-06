using Microsoft.EntityFrameworkCore;
using SocialNetData;
using SocialNetData.Models;
using SocialNetServices.Interfaces;
using SocialNetServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetServices.Services
{
    /// <summary>
    /// Серсвис пользователя
    /// </summary>
    public class UserService : IUserService
    {
        private readonly DataContext _db;
        public UserService(DataContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> Registration(UserRegistrationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName)) throw new Exception("Укажите имя");
            if (string.IsNullOrWhiteSpace(request.SecondName)) throw new Exception("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(request.Login)) throw new Exception("Укажите логин");
            if (string.IsNullOrWhiteSpace(request.Password)) throw new Exception("Укажите пароль");

            var isExist = await _db.Users.AnyAsync(x => x.Login == request.Login);

            if (isExist)
                return false;

            await _db.AddAsync(new User()
            {
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                Login = request.Login,
                Password = request.Password
            });

            await _db.SaveChangesAsync();

            return true;
        }


        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> Login(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Login)) throw new Exception("Введите логин");
            if (string.IsNullOrWhiteSpace(request.Password)) throw new Exception("Введите пароль");


            var user = await _db.Users.FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == request.Password);


            if (user == null)
                throw new Exception("Пользователь не найден");
            else
                return user.Id;
        }


        /// <summary>
        /// Получить информацию о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetUserResponse> GetUser(int id)
        {
            var user = await _db.Users.Where(x => x.Id == id).Select(x => new GetUserResponse()
            {
                FirstName = x.FirstName,
                SecondName = x.SecondName
            }).FirstOrDefaultAsync();

            return user;
        }
    }
}
