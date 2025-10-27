using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    // View (экран) для отображения списка друзей пользователя
    // Показывает всех друзей текущего пользователя в удобном формате
    public class UserFriendView
    {
        // Основной метод для отображения списка друзей
        // Принимает коллекцию друзей (объектов User)
        public void Show(IEnumerable<User> friends)
        {
            // Заголовок экрана
            Console.WriteLine("Мои друзья");

            // Проверка на пустой список друзей
            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас нет друзей");
                return;  // Завершаем выполнение если друзей нет
            }

            // Для каждого друга в списке выводим информацию
            friends.ToList().ForEach(friend =>
            {
                // Форматированный вывод информации о друге
                Console.WriteLine("Почтовый адрес друга: {0}. Имя друга: {1}. Фамилия друга: {2}",
                    friend.Email, friend.FirstName, friend.LastName);
            });
        }
    }
}