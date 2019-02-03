using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public interface IDAOUser
    {
        User GetUserById(int id);
        User GetUserByLogin(string login);
        User LoginUser(string login, string password);
        List<User> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
