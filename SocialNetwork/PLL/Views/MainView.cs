using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    // Главный View (экран) приложения - точка входа в систему
    // Предоставляет пользователю выбор между входом и регистрацией
    public class MainView
    {
        // Основной метод отображения главного меню приложения
        public void Show()
        {
            // Отображаем варианты действий для пользователя
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");

            // Читаем выбор пользователя
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        // Пользователь выбрал вход - показываем экран аутентификации
                        Program.authenticationView.Show();
                        break;
                    }
                case "2":
                    {
                        // Пользователь выбрал регистрацию - показываем экран регистрации
                        Program.registrationView.Show();
                        break;
                    }
                    // Примечание: нет обработки неверного ввода - просто завершится метод
            }
        }
    }
}
