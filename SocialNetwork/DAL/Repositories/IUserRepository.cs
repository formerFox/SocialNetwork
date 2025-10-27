using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DAL.Repositories
{
    public interface IUserRepository
    {
        int Create(UserEntity userEntity);                    // Создать
        UserEntity FindByEmail(string email);                // Найти по email
        IEnumerable<UserEntity> FindAll();                   // Найти всех
        UserEntity FindById(int id);                         // Найти по ID
        int Update(UserEntity userEntity);                   // Обновить
        int DeleteById(int id);                              // Удалить
    }
}
