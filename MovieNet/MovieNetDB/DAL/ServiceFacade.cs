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
        private readonly DAOComment daoComment;
        private readonly DataModelContainer context;

        public ServiceFacade()
        {
            context = new DataModelContainer();
            daoUser = new DAOUser(context);
            daoMovie = new DAOMovie(context);
            daoComment = new DAOComment(context);
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

        public int LoginUser(string login, string password)
        {
            User user = daoUser.LoginUser(login, password);

            User user2 = daoUser.GetUserByLogin(login);

            if (user == null)
            {
                MessageBox.Show("Error information incorrect", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            else
            {
                MessageBox.Show("Welcome !", "Information correct", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return user2.Id;
            }
        }

        public User GetUserByLogin(string login)
        {
            User user = daoUser.GetUserByLogin(login);
            
            return user;
        }

        public User GetUserById(int id)
        {
            User user = daoUser.GetUserById(id);

            return user;
        }

        public void CreateMovie(string title, string genre, string summary, User user)
        {
            var movieAlreadyExist = daoMovie.CheckIfExist(title);

            if (movieAlreadyExist == null)
            {
                Movie movie = new Movie
                {
                    Title = title,
                    Genre = genre,
                    Summary = summary,
                    User = user
                };

                daoMovie.CreateMovie(movie);
                MessageBox.Show("Your movie has been succesfully created", "Movie created", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Error this movie already exist", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = daoMovie.GetMovies();
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            Movie movie = daoMovie.GetMovieById(id);

            return movie;
        }

        public Movie GetMovieByTitle(string title)
        {
            Movie movie = daoMovie.GetMovieByTitle(title);

            return movie;
        }

        public void CreateComment(string _comment, User user, Movie movie)
        {
            Comment comment = new Comment
            {
                MovieComment = _comment,
                User = user,
                Movie = movie
            };
            Console.WriteLine(comment.MovieComment);
            daoComment.CreateComment(comment);
        }

        public List<Comment> GetCommentsByMovieId(int id)
        {
            List<Comment> comments = daoComment.GetCommentsByMovieId(id);

            return comments;
        }
        
    }
}
