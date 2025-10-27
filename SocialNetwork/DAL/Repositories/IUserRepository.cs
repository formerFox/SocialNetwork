using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    // Интерфейс репозитория для работы с пользователями
    // Определяет контракт для CRUD операций с сущностью User
    public interface IUserRepository
    {
        int Create(UserEntity userEntity);          // Создать нового пользователя в базе данных. Возвращает ID созданного пользователя
        UserEntity FindByEmail(string email);       // Найти пользователя по email адресу. Возвращает UserEntity или null если не найден
        IEnumerable<UserEntity> FindAll();          // Получить всех пользователей из базы данных. Возвращает коллекцию всех пользователей
        UserEntity FindById(int id);                // Найти пользователя по уникальному идентификатору. Возвращает UserEntity или null если не найден
        int Update(UserEntity userEntity);          // Обновить данные пользователя в базе данных. Возвращает количество обновленных записей (обычно 1)
        int DeleteById(int id);                     // Удалить пользователя по ID. Возвращает количество удаленных записей (обычно 1)
    }
}
