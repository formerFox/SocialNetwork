using SocialNetwork.BLL.Exceptions;
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
    // View (экран) для добавления пользователя в друзья
    // Отвечает за взаимодействие с пользователем и отображение интерфейса
    public class AddingFriendView
    {
        // Зависимость от сервиса пользователей для выполнения бизнес-логики
        UserService userService;

        // Конструктор принимает сервис через Dependency Injection
        public AddingFriendView(UserService userService)
        {
            this.userService = userService;
        }

        // Основной метод отображения экрана добавления друга
        // Принимает текущего пользователя для которого выполняется операция
        public void Show(User user)
        {
            try
            {
                // Создаем DTO для передачи данных в сервис
                var userAddingFriendData = new UserAddingFriendData();

                // Запрашиваем у пользователя email друга которого нужно добавить
                Console.WriteLine("Введите почтовый адрес пользователя которого хотите добавить в друзья: ");

                // Читаем ввод пользователя
                userAddingFriendData.FriendEmail = Console.ReadLine();
                // Устанавливаем ID текущего пользователя как инициатора операции
                userAddingFriendData.UserId = user.Id;

                // Вызываем сервис для выполнения бизнес-логики добавления друга
                this.userService.AddFriend(userAddingFriendData);

                // Показываем сообщение об успехе зеленым цветом
                SuccessMessageHelper.Show("Вы успешно добавили пользователя в друзья!");
            }
            // Обработка конкретного исключения - пользователь не найден
            catch (UserNotFoundException)
            {
                AlertMessageHelper.Show("Пользователя с указанным почтовым адресом не существует!");
            }
            // Общая обработка всех других исключений
            catch (Exception)
            {
                AlertMessageHelper.Show("Произошла ошибка при добавлении пользователя в друзья!");
            }
        }
    }
}