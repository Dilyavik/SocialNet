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
    }
}
