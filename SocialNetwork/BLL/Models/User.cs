using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class User
    {
        public int Id { get; }                                  // Уникальный идентификатор пользователя (соответствует полю 'id' в таблице 'users')
        public string FirstName { get; set; }                   // Имя пользователя (соответствует полю 'firstname' в таблице 'users')
        public string LastName { get; set; }                    // Фамилия пользователя (соответствует полю 'lastname' в таблице 'users')
        public string Password { get; set; }                    // Пароль пользователя (соответствует полю 'password' в таблице 'users')
        public string Email { get; set; }                       // Email пользователя (соответствует полю 'email' в таблице 'users')
        public string Photo { get; set; }                       // Фотография пользователя (соответствует полю 'photo' в таблице 'users')
        public string FavoriteMovie { get; set; }               // Любимый фильм пользователя (соответствует полю 'favorite_movie' в таблице 'users')
        public string FavoriteBook { get; set; }                // Любимая книга пользователя (соответствует полю 'favorite_book' в таблице 'users')

        public IEnumerable<Message> IncomingMessages { get; }   // Коллекция входящих сообщений для этого пользователя. Содержит все сообщения, где пользователь является получателем (recipient_id)
        public IEnumerable<Message> OutgoingMessages { get; }   // Коллекция исходящих сообщений от этого пользователя. Содержит все сообщения, где пользователь является отправителем (sender_id)
        public IEnumerable<User> Friends { get; }                // Коллекция друзей пользователя. // Содержит объекты User, которые являются друзьями текущего пользователя

        public User(
            int id,
            string firstName,
            string lastName,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook,

            IEnumerable<Message> incomingMessages,
            IEnumerable<Message> outgoingMessages,
            IEnumerable<User> friends
            )
        {
            // Присваивание базовых свойств пользователя
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Email = email;
            this.Photo = photo;
            this.FavoriteMovie = favoriteMovie;
            this.FavoriteBook = favoriteBook;

            // Присваивание связанных данных (навигационные свойства)
            this.IncomingMessages = incomingMessages;
            this.OutgoingMessages = outgoingMessages;
            this.Friends = friends;
        }

        // Упрощенный конструктор для случаев когда не нужны все связи
        public User(int id, string firstName, string lastName, string password, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Email = email;
            // Остальные свойства можно инициализировать пустыми коллекциями
            this.IncomingMessages = new List<Message>();
            this.OutgoingMessages = new List<Message>();
            this.Friends = new List<User>();
        }
    }
}