using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Базовый класс репозитория, предоставляющий общие методы для работы с базой данных
    /// Использует Dapper для простого и эффективного доступа к данным
    /// </summary>

    public class BaseRepository
    {
        // Ищет ОДНУ запись в базе или возвращает null если не нашел. Используется для операций поиска по уникальным полям (id, email)
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            // using гарантирует правильное закрытие и освобождение соединения
            using (var connection = CreateConnection())
            {
                connection.Open();
                // Dapper метод: выполняет SQL запрос и возвращает первую запись или default(T)
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        // Ищет ВСЕ подходящие записи и возвращает список
        // Используется для операций, которые возвращают множественные результаты
        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                // Dapper метод: выполняет SQL запрос и возвращает все подходящие записи
                // ToList() преобразует результат в List<T> для удобства работы
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        // Выполняет команды: INSERT, UPDATE, DELETE
        // Возвращает количество затронутых строк
        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                // Dapper метод: выполняет SQL команду (не запрос)
                // Возвращает количество измененных/добавленных/удаленных строк
                return connection.Execute(sql, parameters);
            }
        }

        // Создание подключения к базе данных SQLite
        // Это настройка подключения к файлу базы данных social_network.db в папке DAL/DB/
        private IDbConnection CreateConnection()
        {
            // Создает новое соединение с SQLite базой данных
            // Data Source - путь к файлу базы данных
            // Version = 3 - версия SQLite
            return new SQLiteConnection("Data Source = DAL/DB/social_network.db; Version = 3");
        }
    }
}
