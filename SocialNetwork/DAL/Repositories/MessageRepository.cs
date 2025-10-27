using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с сообщениями
    /// Наследуется от BaseRepository для доступа к базовым методам работы с БД
    /// Реализует интерфейс IMessageRepository для соблюдения контракта
    /// </summary>

    public class MessageRepository : BaseRepository, IMessageRepository
    {
        // Создать новое сообщение в базе данных
        // Возвращает количество добавленных записей (обычно 1)
        public int Create(MessageEntity messageEntity)
        {
            // SQL запрос на вставку нового сообщения
            // Указываем конкретные поля для ясности (id генерируется автоматически)
            return Execute(@"insert into messages(content, sender_id, recipient_id) 
                             values(:content,:sender_id,:recipient_id)", messageEntity);
        }

        // Найти все сообщения по ID отправителя
        // Возвращает коллекцию исходящих сообщений пользователя
        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            // SQL запрос для поиска всех сообщений, отправленных пользователем
            return Query<MessageEntity>("select * from messages where sender_id = :sender_id", new { sender_id = senderId });
        }

        // Найти все сообщения по ID получателя
        // Возвращает коллекцию входящих сообщений пользователя
        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            // SQL запрос для поиска всех сообщений, полученных пользователем
            return Query<MessageEntity>("select * from messages where recipient_id = :recipient_id", new { recipient_id = recipientId });
        }

        // Удалить сообщение по ID
        // Возвращает количество удаленных записей (обычно 1)
        public int DeleteById(int messageId)
        {
            // SQL запрос на удаление сообщения по его уникальному идентификатору
            return Execute("delete from messages where id = :id", new { id = messageId });
        }

    }

}
