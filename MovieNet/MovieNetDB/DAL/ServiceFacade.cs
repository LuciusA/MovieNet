using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieNetDB.DAL
{
    public class ServiceFacade
    {
        private static ServiceFacade INSTANCE = null;
        private readonly DAOUser daoUser;
        private readonly DAOMovie daoMovie;
        private readonly DataModelContainer context;

        public ServiceFacade()
        {
            context = new DataModelContainer();
            daoUser = new DAOUser(context);
            daoMovie = new DAOMovie(context);
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
            var userAlreadyExist = daoUser.GetUserByLogin(login);

            if (userAlreadyExist == null)
            {
                User user = new User
                {
                    Login = login,
                    Password = password
                };

                daoUser.CreateUser(user);
                MessageBox.Show("Your registration is complete", "User created", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Error login already taken", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoginUser(string login, string password)
        {
            User user = daoUser.LoginUser(login, password);

            if (user == null)
            {
                MessageBox.Show("Error information incorrect", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Welcome !", "Information correct", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        public void CreateMovie(string title, string genre, string summary, double rating, int userId)
        {
            var movieAlreadyExist = daoMovie.CheckIfExist(title);

            if (movieAlreadyExist == null)
            {
                Movie movie = new Movie
                {
                    Title = title,
                    Genre = genre,
                    Summary = summary,
                    User_id = userId
                };

                daoMovie.CreateMovie(movie);
                MessageBox.Show("Your movie has been succesfully created", "Movie created", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Error this movie already exist", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
