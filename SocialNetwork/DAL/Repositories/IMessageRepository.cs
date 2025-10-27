using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    // Интерфейс репозитория для работы с сообщениями
    // Определяет контракт для операций с сущностью Message
    public interface IMessageRepository
    {
        int Create(MessageEntity messageEntity);                        // Создать новое сообщение в базе данных. Возвращает ID созданного сообщения
        IEnumerable<MessageEntity> FindBySenderId(int senderId);        // Найти все сообщения по ID отправителя. Возвращает коллекцию исходящих сообщений пользователя
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);  // Найти все сообщения по ID получателя. Возвращает коллекцию входящих сообщений пользователя
        int DeleteById(int messageId);                                  // Удалить сообщение по ID. Возвращает количество удаленных записей (обычно 1)
    }
}
