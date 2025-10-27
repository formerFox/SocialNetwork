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
    // View (экран) для аутентификации пользователя (входа в систему)
    // Отвечает за взаимодействие с пользователем при входе в аккаунт
    public class AuthenticationView
    {
        // Зависимость от сервиса пользователей для выполнения аутентификации
        UserService userService;

        // Конструктор принимает сервис через Dependency Injection
        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        // Основной метод отображения экрана аутентификации
        public void Show()
        {
            // Создаем DTO для передачи учетных данных в сервис
            var authenticationData = new UserAuthenticationData();

            // Запрашиваем у пользователя email (логин)
            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            // Запрашиваем у пользователя пароль
            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                // Вызываем сервис для выполнения аутентификации
                // Сервис проверяет существование пользователя и корректность пароля
                var user = this.userService.Authenticate(authenticationData);

                // Показываем сообщение об успешном входе
                SuccessMessageHelper.Show("Вы успешно вошли в социальную сеть!");

                // Приветствуем пользователя по имени
                SuccessMessageHelper.Show("Добро пожаловать " + user.FirstName);

                // Переходим к главному меню пользователя
                // Program.userMenuView - вероятно, статическая ссылка на главное меню
                Program.userMenuView.Show(user);
            }
            // Обработка исключения - неверный пароль
            catch (WrongPasswordException)
            {
                AlertMessageHelper.Show("Пароль не корректный!");
            }
            // Обработка исключения - пользователь не найден
            catch (UserNotFoundException)
            {
                AlertMessageHelper.Show("Пользователь не найден!");
            }
            // Примечание: нет общего catch(Exception) - возможно, ошибки передаются выше
        }
    }
}