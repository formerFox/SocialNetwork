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
    public class BaseRepository
    {
        // Ищет ОДНУ запись в базе или возвращает null если не нашел
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        // Ищет ВСЕ подходящие записи и возвращает список
        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        // Выполняет команды: INSERT, UPDATE, DELETE
        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        //Это настройка подключения к файлу базы данных social_network.db в папке DAL/DB/.
        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = DAL/DB/social_network.db; Version = 3");
        }
    }
}
