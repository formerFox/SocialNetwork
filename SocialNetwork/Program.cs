using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

class Program
{
    // Статические поля для сервисов бизнес-логики
    static MessageService messageService;
    static UserService userService;

    // Статические поля для всех Views (экранов) приложения
    public static MainView mainView;
    public static RegistrationView registrationView;
    public static AuthenticationView authenticationView;
    public static UserMenuView userMenuView;
    public static UserInfoView userInfoView;
    public static UserDataUpdateView userDataUpdateView;
    public static MessageSendingView messageSendingView;
    public static UserIncomingMessageView userIncomingMessageView;
    public static UserOutcomingMessageView userOutcomingMessageView;
    public static AddingFriendView addingFriendView;
    public static UserFriendView userFriendView;

    // Точка входа в приложение
    static void Main(string[] args)
    {
        // Инициализация сервисов бизнес-логики
        userService = new UserService();
        messageService = new MessageService();

        // Инициализация всех Views приложения
        // Передаем необходимые зависимости в конструкторы
        mainView = new MainView();
        registrationView = new RegistrationView(userService);
        authenticationView = new AuthenticationView(userService);
        userMenuView = new UserMenuView(userService);
        userInfoView = new UserInfoView();
        userDataUpdateView = new UserDataUpdateView(userService);
        messageSendingView = new MessageSendingView(messageService, userService);
        userIncomingMessageView = new UserIncomingMessageView();
        userOutcomingMessageView = new UserOutcomingMessageView();
        addingFriendView = new AddingFriendView(userService);
        userFriendView = new UserFriendView();

        // Главный цикл приложения
        while (true)
        {
            // Запуск главного меню приложения
            mainView.Show();
        }
    }
}