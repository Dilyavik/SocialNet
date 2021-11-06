using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetServices.Models
{
    public class GetUserResponse
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
