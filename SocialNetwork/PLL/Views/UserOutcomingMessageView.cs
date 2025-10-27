using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    // View (экран) для отображения исходящих сообщений пользователя
    // Показывает все сообщения, которые пользователь отправил другим
    public class UserOutcomingMessageView
    {
        // Основной метод для отображения исходящих сообщений
        // Принимает коллекцию исходящих сообщений
        public void Show(IEnumerable<Message> outcomingMessages)
        {
            // Заголовок экрана
            Console.WriteLine("Исходящие сообщения");

            // Проверка на пустой список сообщений
            if (outcomingMessages.Count() == 0)
            {
                Console.WriteLine("Исходящих сообщений нет");
                return;  // Завершаем выполнение если сообщений нет
            }

            // Для каждого сообщения в списке выводим информацию
            outcomingMessages.ToList().ForEach(message =>
            {
                // Вывод информации о сообщении
                Console.WriteLine("Кому: {0}. Текст сообщения: {1}",
                    message.RecipientId, message.Content);
            });
        }
    }
}