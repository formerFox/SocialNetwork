using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    // Основной сервис для работы с пользователями - содержит всю бизнес-логику пользователей
    public class UserService
    {
        // Зависимости от других сервисов и репозиториев
        MessageService messageService;
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        // Конструктор инициализирует все зависимости
        public UserService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
            messageService = new MessageService();
        }

        // Регистрация нового пользователя с полной валидацией данных
        public void Register(UserRegistrationData userRegistrationData)
        {
            // Комплексная валидация данных регистрации
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            // Валидация длины пароля (минимум 8 символов)
            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();

            // Валидация формата email с помощью System.ComponentModel.DataAnnotations
            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();

            // Проверка уникальности email в системе
            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            // Создание Entity для сохранения в БД
            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            // Сохранение в БД и проверка успешности
            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();

        }

        // Аутентификация пользователя (вход в систему)
        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            // Поиск пользователя по email
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();

            // Проверка пароля
            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            // Возврат полной бизнес-модели пользователя
            return ConstructUserModel(findUserEntity);
        }

        // Поиск пользователя по email с возвратом полной модели
        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        // Поиск пользователя по ID с возвратом полной модели
        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        // Обновление данных пользователя
        public void Update(User user)
        {
            // Создание Entity из бизнес-модели для обновления
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            // Сохранение изменений в БД
            if (this.userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        // Получение списка друзей пользователя
        public IEnumerable<User> GetFriendsByUserId(int userId)
        {
            // Находим все записи о друзьях и преобразуем в полные модели пользователей
            return friendRepository.FindAllByUserId(userId)
                    .Select(friendsEntity => FindById(friendsEntity.friend_id));
        }

        // Добавление пользователя в друзья
        public void AddFriend(UserAddingFriendData userAddingFriendData)
        {
            // Поиск пользователя по email (того, кого добавляем в друзья)
            var findUserEntity = userRepository.FindByEmail(userAddingFriendData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            // Создание записи о дружбе
            var friendEntity = new FriendEntity()
            {
                user_id = userAddingFriendData.UserId,
                friend_id = findUserEntity.id
            };

            // Сохранение в БД
            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        // Приватный метод для построения полной бизнес-модели пользователя
        // Собирает все связанные данные: сообщения, друзей и т.д.
        private User ConstructUserModel(UserEntity userEntity)
        {
            // Получение входящих и исходящих сообщений через MessageService
            var incomingMessages = messageService.GetIncomingMessagesByUserId(userEntity.id);
            var outgoingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);

            // Получение списка друзей
            var friends = GetFriendsByUserId(userEntity.id);

            // Создание полной бизнес-модели со всеми связанными данными
            return new User(userEntity.id,
                          userEntity.firstname,
                          userEntity.lastname,
                          userEntity.password,
                          userEntity.email,
                          userEntity.photo,
                          userEntity.favorite_movie,
                          userEntity.favorite_book,
                          incomingMessages,
                          outgoingMessages,
                          friends
                          );
        }
    }
}