using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    // Сервис для работы с сообщениями - содержит бизнес-логику операций с сообщениями
    public class MessageService
    {
        // Зависимости от репозиториев для работы с данными
        IMessageRepository _messageRepository;
        IUserRepository _userRepository;

        // Конструктор по умолчанию - создает конкретные реализации репозиториев
        public MessageService()
        {
            _userRepository = new UserRepository();
            _messageRepository = new MessageRepository();
        }

        // Получить все входящие сообщения для пользователя по его ID
        // Возвращает коллекцию сообщений с информацией об отправителях и получателях
        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();

            // Получаем все сообщения где пользователь является получателем
            _messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                // Для каждого сообщения находим полную информацию об отправителе и получателе
                var senderUserEntity = _userRepository.FindById(m.sender_id);
                var recipientUserEntity = _userRepository.FindById(m.recipient_id);

                // Создаем бизнес-модель Message с email адресами вместо ID
                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        // Получить все исходящие сообщения от пользователя по его ID
        // Возвращает коллекцию сообщений с информацией об отправителях и получателях
        public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Message>();

            // Получаем все сообщения где пользователь является отправителем
            _messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
            {
                // Для каждого сообщения находим полную информацию об отправителе и получателе
                var senderUserEntity = _userRepository.FindById(m.sender_id);
                var recipientUserEntity = _userRepository.FindById(m.recipient_id);

                // Создаем бизнес-модель Message с email адресами вместо ID
                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        // Отправить новое сообщение
        // Выполняет валидацию и бизнес-логику перед сохранением сообщения
        public void SendMessage(MessageSendingData messageSendingData)
        {
            // Валидация: сообщение не может быть пустым
            if (String.IsNullOrEmpty(messageSendingData.Content))
                throw new ArgumentNullException();

            // Валидация: ограничение длины сообщения (5000 символов)
            if (messageSendingData.Content.Length > 5000)
                throw new ArgumentOutOfRangeException();

            // Проверка существования получателя по email
            var findUserEntity = this._userRepository.FindByEmail(messageSendingData.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            // Создаем Entity для сохранения в БД
            var messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                sender_id = messageSendingData.SenderId,
                recipient_id = findUserEntity.id                        // Преобразуем email в ID получателя
            };

            // Сохраняем сообщение и проверяем успешность операции
            if (this._messageRepository.Create(messageEntity) == 0)
                throw new Exception();                                  // Сообщение не было создано
        }
    }
}