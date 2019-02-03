using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public class ServiceFacade
    {
        private static ServiceFacade INSTANCE = null;
        private readonly DAOUser daoUser;
        private readonly DataModelContainer context;

        public ServiceFacade()
        {
            context = new DataModelContainer();
            daoUser = new DAOUser(context);
        }

        public static ServiceFacade Instance
        {
            get
            {
                if (INSTANCE == null) INSTANCE = new ServiceFacade();
                return INSTANCE;
            }
        }

        public void CreateUser(string login, string password)
        {
            Console.WriteLine("Service Facade");
            User user = new User
            {
                Login = login,
                Password = password
            };
            Console.WriteLine(user.Login);
            daoUser.CreateUser(user);
        }
    }
}
