using SocialNetServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetServices.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса пользователя
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<bool> Registration(UserRegistrationRequest request);
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> Login(LoginRequest request);
        /// <summary>
        /// Получить информацию о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<GetUserResponse> GetUser(int id);
    }
}
