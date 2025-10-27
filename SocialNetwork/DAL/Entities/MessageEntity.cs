using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities
{
    /// <summary>
    /// класс - представляет запись в таблице базы данных
    /// свойства совпадают с названиями полей в таблице
    /// DAL слой - используется для работы с сообщениями в БД 
    /// Этот класс точно соответствует структуре таблицы 'messages' в БД
    /// </summary>
    public class MessageEntity
    {
        public int id { get; set; }             // Уникальный идентификатор сообщения (первичный ключ). Соответствует полю 'id' в таблице 'messages'
        public string content { get; set; }     // Текст сообщения. Соответствует полю 'content' в таблице 'messages'
        public int sender_id { get; set; }      // ID пользователя-отправителя сообщения. 
        public int recipient_id { get; set; }   // ID пользователя-получателя сообщения.
    }
}
