using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    /// <summary>
    /// Реализация репозитория для работы с друзьями
    /// Наследуется от BaseRepository для доступа к базовым методам работы с БД
    /// Реализует интерфейс IFriendRepository для соблюдения контракта
    /// </summary>

    public class FriendRepository : BaseRepository, IFriendRepository
    {
        // Найти все записи о друзьях по ID пользователя
        // Возвращает коллекцию записей о дружбе для указанного пользователя
        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            // SQL запрос с параметром :user_id
            // Dapper автоматически маппит результат на FriendEntity
            return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
        }

        // Создать новую запись о дружбе между пользователями
        // Возвращает количество добавленных записей (обычно 1)
        public int Create(FriendEntity friendEntity)
        {
            // SQL запрос на вставку новой записи
            // Dapper автоматически маппит свойства friendEntity на параметры :user_id, :friend_id
            return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
        }

        // Удалить запись о дружбе по ID
        // Возвращает количество удаленных записей (обычно 1)
        public int Delete(int id)
        {
            // SQL запрос на удаление с параметром :id_p
            // Используется псевдоним :id_p чтобы избежать конфликта имен
            return Execute(@"delete from friends where id = :id_p", new { id_p = id });
        }
    }
}
