using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public interface IDAOUser
    {
        void CreateUser(User user);
        User GetUserById(int id);
        User GetUserByLogin(string login);
        List<User> GetUsers();
        void UpdateUser(int id, string login, string password);
        void DeleteUser(int id);
        User LoginUser(string login, string password);
    }
}
