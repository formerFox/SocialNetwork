using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    // Интерфейс репозитория для работы с друзьями
    // Определяет контракт для операций с сущностью Friend
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);                  // Создать новую связь дружбы между пользователями. Возвращает ID созданной записи о дружбе
        IEnumerable<FriendEntity> FindAllByUserId(int userId);  // Найти всех друзей пользователя по его ID. Возвращает коллекцию записей о дружбе
        int Delete(int id);                                     // Удалить связь дружбы по ID записи. Возвращает количество удаленных записей (обычно 1)
    }
}
