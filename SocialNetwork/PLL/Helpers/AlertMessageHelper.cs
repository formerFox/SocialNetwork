using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Helpers
{
    // Хелпер для отображения сообщений об ошибках и предупреждений
    // Использует красный цвет для привлечения внимания пользователя
    public class AlertMessageHelper
    {
        // Статический метод для отображения сообщения об ошибке
        // message - текст сообщения который будет показан пользователю
        public static void Show(string message)
        {
            // Сохраняем оригинальный цвет консоли чтобы восстановить его после вывода
            ConsoleColor originalColor = Console.ForegroundColor;

            // Устанавливаем красный цвет для сообщений об ошибках
            Console.ForegroundColor = ConsoleColor.Red;

            // Выводим сообщение
            Console.WriteLine(message);

            // Восстанавливаем оригинальный цвет консоли
            Console.ForegroundColor = originalColor;
        }
    }
}
