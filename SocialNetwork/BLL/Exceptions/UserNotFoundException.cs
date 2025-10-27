using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Exceptions
{
    // Пользовательское исключение для случаев когда пользователь не найден в системе
    // Наследуется от стандартного Exception для интеграции с существующей инфраструктурой
    public class UserNotFoundException : Exception
    {
        // Базовый конструктор - позволяет создавать исключение без сообщения
        // Сообщение по умолчанию будет взято из базового класса
    }
}
