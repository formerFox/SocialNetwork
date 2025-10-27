using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    // Главное меню пользователя после успешной аутентификации
    // Центральный хаб для навигации по всем функциям социальной сети
    public class UserMenuView
    {
        // Зависимость от сервиса пользователей для обновления данных
        UserService userService;

        // Конструктор принимает сервис через Dependency Injection
        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        // Основной метод отображения меню пользователя
        // Принимает текущего аутентифицированного пользователя
        public void Show(User user)
        {
            // Бесконечный цикл меню (пока пользователь не выберет выход)
            while (true)
            {
                // Статистика профиля в шапке меню
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие сообщения: {0}", user.OutgoingMessages.Count());
                Console.WriteLine("Мои друзья: {0}", user.Friends.Count());

                // Основные опции меню
                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Просмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Просмотреть исходящие сообщения (нажмите 6)");
                Console.WriteLine("Просмотреть моих друзей (нажмите 7)");
                Console.WriteLine("Выйти из профиля (нажмите 8)");

                // Чтение выбора пользователя
                string keyValue = Console.ReadLine();

                // Выход из меню (и возврат в главное меню приложения)
                if (keyValue == "8") break;

                // Обработка выбора пользователя
                switch (keyValue)
                {
                    case "1":
                        {
                            // Просмотр информации о профиле
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            // Редактирование профиля
                            Program.userDataUpdateView.Show(user);
                            // Обновляем данные пользователя после редактирования
                            user = userService.FindById(user.Id);
                            break;
                        }

                    case "3":
                        {
                            // Добавление нового друга
                            Program.addingFriendView.Show(user);
                            // Обновляем данные пользователя (добавился друг)
                            user = userService.FindById(user.Id);
                            break;
                        }

                    case "4":
                        {
                            // Отправка сообщения
                            Program.messageSendingView.Show(user);
                            // Обновляем данные пользователя (добавилось сообщение)
                            user = userService.FindById(user.Id);
                            break;
                        }

                    case "5":
                        {
                            // Просмотр входящих сообщений
                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }

                    case "6":
                        {
                            // Просмотр исходящих сообщений
                            Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }

                    case "7":
                        {
                            // Просмотр списка друзей
                            Program.userFriendView.Show(user.Friends);
                            break;
                        }
                }
            }
        }
    }
}