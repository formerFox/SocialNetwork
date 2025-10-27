using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Entities
{
    /// <summary>
    /// класс - представляет запись в таблице базы данных
    /// свойства совпадают с названиями полей в таблице
    /// DAL слой - используется для работы с пользователями в БД 
    /// Этот класс точно соответствует структуре таблицы 'users' в БД
    /// </summary>
    public class UserEntity
    {
        public int id { get; set; }                 // Уникальный идентификатор пользователя (первичный ключ). Соответствует полю 'id' в таблице 'users'
        public string firstname { get; set; }       // Имя пользователя. Соответствует полю 'firstname' в таблице 'users'
        public string lastname { get; set; }        // Фамилия пользователя. Соответствует полю 'lastname' в таблице 'users'
        public string password { get; set; }        // Пароль пользователя. Соответствует полю 'password' в таблице 'users'
        public string email { get; set; }           // Email пользователя (уникальный). Соответствует полю 'email' в таблице 'users'
        public string photo { get; set; }           // Фотография пользователя. Соответствует полю 'photo' в таблице 'users'
        public string favorite_movie { get; set; }  // Любимый фильм пользователя. Соответствует полю 'favorite_movie' в таблице 'users'
        public string favorite_book { get; set; }   // Любимая книга пользователя. Соответствует полю 'favorite_book' в таблице 'users'
    }
}
