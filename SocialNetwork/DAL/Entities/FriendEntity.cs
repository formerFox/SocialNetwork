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
    /// DAL слой - используется для работы с базой данных 
    /// </summary>
    public class FriendEntity
    {
        public int id { get; set; }         // Уникальный идентификатор записи о дружбе (первичный ключ). Соответствует полю 'id' в таблице 'friends'
        public int user_id { get; set; }    // ID пользователя, КОТОРЫЙ добавляет в друзья. Внешний ключ, ссылается на 'id' в таблице 'users'. Соответствует полю 'user_id' в таблице 'friends'
        public int friend_id { get; set; }  // ID пользователя, КОТОРОГО добавляют в друзья. Внешний ключ, ссылается на 'id' в таблице 'users'. Соответствует полю 'friend_id' в таблице 'friends'
    }
}
