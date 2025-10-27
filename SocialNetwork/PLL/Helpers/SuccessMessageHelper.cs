using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Helpers
{
    // Хелпер для отображения успешных операций и подтверждений
    // Использует зеленый цвет для позитивной обратной связи
    public class SuccessMessageHelper
    {
        // Статический метод для отображения сообщения об успехе
        // message - текст сообщения который будет показан пользователю
        public static void Show(string message)
        {
            // Сохраняем оригинальный цвет консоли
            ConsoleColor originalColor = Console.ForegroundColor;

            // Устанавливаем зеленый цвет для успешных операций
            Console.ForegroundColor = ConsoleColor.Green;

            // Выводим сообщение
            Console.WriteLine(message);

            // Восстанавливаем оригинальный цвет консоли
            Console.ForegroundColor = originalColor;
        }
    }
}
