using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    //DTO (Data Transfer Object) - класс для передачи данных между слоями приложения
    public class MessageSendingData
    {
        public int SenderId { get; set; }           // ID пользователя-отправителя сообщения
        public string Content { get; set; }         // Текст сообщения, который будет отправлен
        public string RecipientEmail { get; set; }  // Email пользователя-получателя сообщения
    }
}
