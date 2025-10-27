using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    /// <summary>
    /// DTO (Data Transfer Object) - предназначен только для передачи данных регистрации
    /// Специализирован для создания пользователя - содержит все данные для создания нового аккаунта
    /// Связывает PLL и BLL слои - передает данные из формы регистрации в сервис регистрации
    /// </summary>
    public class UserRegistrationData
    {
        public string FirstName { get; set; }   // Имя нового пользователя. Будет сохранено в поле 'firstname' в таблице 'users'
        public string LastName { get; set; }    // Фамилия нового пользователя. Будет сохранено в поле 'lastname' в таблице 'users'
        public string Password { get; set; }    // Пароль для нового аккаунта. Будет сохранен в поле 'password' в таблице 'users'
        public string Email { get; set; }       // Email для нового аккаунта. Будет сохранен в поле 'email' в таблице 'users'
    }
}
