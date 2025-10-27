using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{

    /// <summary>
    /// "менеджер пользователей", который умеет выполнять все основные операции с пользователями в базе данных
    /// BaseRepository - получает все методы работы с БД из родительского класса
    /// IUserRepository - обещает реализовать все методы из интерфейса
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        // Создать нового пользователя в базе данных
        // Возвращает количество добавленных записей (обычно 1)
        public int Create(UserEntity userEntity)
        {
            // SQL запрос на вставку нового пользователя
            // Заполняем только обязательные поля при регистрации
            return Execute(@"insert into users (firstname,lastname,password,email) 
                             values (:firstname,:lastname,:password,:email)", userEntity);
        }

        // Получить всех пользователей из базы данных
        // Возвращает коллекцию всех зарегистрированных пользователей
        public IEnumerable<UserEntity> FindAll()
        {
            // Простой SQL запрос без параметров - получаем всех пользователей
            return Query<UserEntity>("select * from users");
        }

        // Найти пользователя по email адресу
        // Возвращает UserEntity или null если пользователь не найден
        public UserEntity FindByEmail(string email)
        {
            // SQL запрос с параметром :email_p для поиска по уникальному email
            // Используется для аутентификации и проверки уникальности email
            return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new { email_p = email });
        }

        // Найти пользователя по уникальному идентификатору
        // Возвращает UserEntity или null если пользователь не найден
        public UserEntity FindById(int id)
        {
            // SQL запрос с параметром :id_p для поиска по первичному ключу
            return QueryFirstOrDefault<UserEntity>("select * from users where id = :id_p", new { id_p = id });
        }

        // Обновить данные пользователя в базе данных
        // Возвращает количество обновленных записей (обычно 1)
        public int Update(UserEntity userEntity)
        {
            // Полный SQL запрос на обновление всех полей пользователя
            // Обновляет как базовые данные, так и дополнительную информацию профиля
            return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password, email = :email,
                             photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id", userEntity);
        }

        // Удалить пользователя по ID
        // Возвращает количество удаленных записей (обычно 1)
        public int DeleteById(int id)
        {
            // SQL запрос на удаление пользователя по первичному ключу
            return Execute("delete from users where id = :id_p", new { id_p = id });
        }
    }

}
