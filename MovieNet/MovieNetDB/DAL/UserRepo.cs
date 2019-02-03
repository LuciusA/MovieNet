using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public class UserRepo : IUserRepo
    {
        private DAOUser dao;

        public UserRepo(DAOUser daoUser)
        {
            dao = daoUser;
        }
        public User GetUserById(int id)
        {
            return dao.GetUserById(id);
        }
        public List<User> GetUsers()
        {
            return dao.GetUsers();
        }
        public void CreateUser(User user)
        {
            dao.CreateUser(user);
        }
        public void UpdateUser(User user)
        {
            dao.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            dao.DeleteUser(id);
        }
    }
}
