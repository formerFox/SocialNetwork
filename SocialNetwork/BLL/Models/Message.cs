using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Message
    {
        public int Id { get; }              // Уникальный идентификатор сообщения
        public string Content { get; }      // Текст сообщения
        public string SenderId { get; }     // ID отправителя сообщения
        public string RecipientId { get; }  // ID получателя сообщения

        // Конструктор для создания объекта сообщения
        public Message(int id, string content, string senderEmail, string recipientEmail)
        {
            this.Id = id;
            this.Content = content;
            this.SenderId = senderEmail;
            this.RecipientId = recipientEmail;
        }

    }
}

