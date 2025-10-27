using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    // Пользовательское исключение для случаев когда введен неверный пароль
    // Используется в процессе аутентификации пользователя
    public class WrongPasswordException : Exception
    {
        // Базовый конструктор - позволяет создавать исключение без сообщения
        // Сообщение по умолчанию будет взято из базового класса
    }
}
