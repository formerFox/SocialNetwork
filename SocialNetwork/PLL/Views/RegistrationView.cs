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
    // View (экран) для регистрации нового пользователя
    // Отвечает за сбор данных и создание нового аккаунта
    public class RegistrationView
    {
        // Зависимость от сервиса пользователей для выполнения регистрации
        UserService userService;

        // Конструктор принимает сервис через Dependency Injection
        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        // Основной метод отображения экрана регистрации
        public void Show()
        {
            // Создаем DTO для передачи данных регистрации в сервис
            var userRegistrationData = new UserRegistrationData();

            // Поэтапно запрашиваем у пользователя данные для регистрации
            Console.WriteLine("Для создания нового профиля введите ваше имя:");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия:");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль:");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Почтовый адрес:");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                // Вызываем сервис для выполнения бизнес-логики регистрации
                // Сервис выполнит валидацию и сохранение в БД
                this.userService.Register(userRegistrationData);

                // Показываем сообщение об успешной регистрации
                SuccessMessageHelper.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }
            // Обработка исключения - некорректные данные (пустые значения)
            catch (ArgumentNullException)
            {
                AlertMessageHelper.Show("Введите корректное значение.");
            }
            // Общая обработка всех других исключений
            catch (Exception)
            {
                AlertMessageHelper.Show("Произошла ошибка при регистрации.");
            }
        }
    }
}