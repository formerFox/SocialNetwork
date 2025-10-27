using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    /// <summary>
    /// DTO (Data Transfer Object) - предназначен только для передачи данных между слоями приложения
    /// Специализирован для одной операции - добавления пользователя в друзья
    /// Связывает PLL и BLL слои - передает данные от пользовательского интерфейса к бизнес-логике
    /// </summary>
    
    public class UserAddingFriendData
    {
        public int UserId { get; set; }             // ID пользователя, который добавляет друга. Идентифицирует того, кто выполняет операцию добавления
        public string FriendEmail { get; set; }     // Email пользователя, которого добавляют в друзья. Используется для поиска пользователя в системе по email адресу
    }
}
