using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public class UserFacade
    {
        private readonly IDAOUser daoUser = new IDAOUser();
        private readonly User user = new User();

        public UserFacade()
        {
        }

        public void CreateUser(string login, string password)
        {
            user.setLogin(login);
            user.setPassword(password);
            daoUser.CreateUser(user);
        }
    }
}
