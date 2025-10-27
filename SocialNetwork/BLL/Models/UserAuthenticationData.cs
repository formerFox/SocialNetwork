using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    /// <summary>
    /// DTO (Data Transfer Object) - предназначен только для передачи данных между слоями приложения
    /// Специализирован для одной операции - авторизации пользователя в системе
    /// Связывает PLL и BLL слои - передает учетные данные от формы входа к сервису аутентификации
    /// </summary>
    public class UserAuthenticationData
    {
        public string Email { get; set; }       // Email пользователя для входа в систему. Используется как логин для идентификации пользователя
        public string Password { get; set; }    // Пароль пользователя для входа в систему. Используется для проверки подлинности пользователя
    }
}
