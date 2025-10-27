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
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;

        public MessageSendingView(MessageService messageService, UserService userService) 
        { 
            this.userService = userService;
            this.messageService = messageService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.WriteLine("Введите почтовый адрес получателя: ");
            messageSendingData.RecipientEmail = Console.ReadLine();
            Console.WriteLine("Введите сообщение (не больше 5000 символов): ");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);
                SuccessMessageHelper.Show("Сообщение успешно отправлено!");
                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException) { AlertMessageHelper.Show("Пользователь не найден!"); }
            catch (ArgumentNullException) { AlertMessageHelper.Show("Введите корректное значение!"); }
            catch (Exception) { AlertMessageHelper.Show("Произошла ошибка при отправке сообщения!"); }
        }
    }
}
