using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    // View (экран) для обновления данных пользователя
    // Позволяет пользователю редактировать информацию своего профиля
    public class UserDataUpdateView
    {
        // Зависимость от сервиса пользователей для выполнения обновления
        UserService userService;

        // Конструктор принимает сервис через Dependency Injection
        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        // Основной метод отображения экрана обновления данных
        // Принимает текущего пользователя для предзаполнения и обновления
        public void Show(User user)
        {
            // Поэтапно запрашиваем обновление данных профиля
            Console.Write("Меня зовут:");
            user.FirstName = Console.ReadLine();

            Console.Write("Моя фамилия:");
            user.LastName = Console.ReadLine();

            Console.Write("Ссылка на моё фото:");
            user.Photo = Console.ReadLine();

            Console.Write("Мой любимый фильм:");
            user.FavoriteMovie = Console.ReadLine();

            Console.Write("Моя любимая книга:");
            user.FavoriteBook = Console.ReadLine();

            // Вызываем сервис для сохранения изменений в базе данных
            this.userService.Update(user);

            // Показываем сообщение об успешном обновлении
            SuccessMessageHelper.Show("Ваш профиль успешно обновлён!");
        }
    }
}