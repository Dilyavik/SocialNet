using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetWeb.Models
{
    public class UserResponse
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string SecondName { get; set; }
    }
}
