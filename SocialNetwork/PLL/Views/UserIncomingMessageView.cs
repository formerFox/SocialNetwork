using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    // View (экран) для отображения входящих сообщений пользователя
    // Показывает все сообщения, которые пользователь получил от других
    public class UserIncomingMessageView
    {
        // Основной метод для отображения входящих сообщений
        // Принимает коллекцию входящих сообщений
        public void Show(IEnumerable<Message> incomingMessages)
        {
            // Заголовок экрана
            Console.WriteLine("Входящие сообщения");

            // Проверка на пустой список сообщений
            if (incomingMessages.Count() == 0)
            {
                Console.WriteLine("Входящих сообщения нет");
                return;  // Завершаем выполнение если сообщений нет
            }

            // Для каждого сообщения в списке выводим информацию
            incomingMessages.ToList().ForEach(message =>
            {
                // Вывод информации о сообщении
                Console.WriteLine("От кого: {0}. Текст сообщения: {1}",
                    message.SenderId, message.Content);
            });
        }
    }
}