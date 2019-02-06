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
        private readonly DAORating daoRating;
        private readonly DataModelContainer context;

        //INIT
        public ServiceFacade()
        {
            context = new DataModelContainer();
            daoUser = new DAOUser(context);
            daoMovie = new DAOMovie(context);
            daoComment = new DAOComment(context);
            daoRating = new DAORating(context);
        }

        //SINGLETON
        public static ServiceFacade Instance
        {
            get
            {
                if (INSTANCE == null)
                    INSTANCE = new ServiceFacade();
                return INSTANCE;
            }
        }

        /*CREATE METHODS*/
        //USER
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
        //MOVIE
        public void CreateMovie(string title, string genre, string summary, double _rating, User user)
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

                Rating rating = new Rating
                {
                    Rate = _rating,
                    User = user,
                    Movie = movie
                };

                daoMovie.CreateMovie(movie);
                daoRating.CreateRating(rating);
                MessageBox.Show("Your movie has been succesfully created", "Movie created", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error this movie already exist", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //COMMENT
        public void CreateComment(string _comment, User user, Movie movie)
        {
            Comment comment = new Comment
            {
                MovieComment = _comment,
                User = user,
                Movie = movie
            };
            daoComment.CreateComment(comment);
        }
        //RATING
        public void CreateRating(double _rating, User user, Movie movie)
        {
            Rating rating = new Rating
            {
                Rate = _rating,
                User = user,
                Movie = movie
            };
            daoRating.CreateRating(rating);
        }
        /*CREATE METHODS*/

        /*GET METHODS*/
        //USER
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
        //MOVIE
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = daoMovie.GetMovies();
            return movies;
        }

        public List<Movie> GetMoviesByUserId(int id)
        {
            List<Movie> movies = daoMovie.GetMoviesByUserId(id);
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
        //COMMENT
        public List<Comment> GetCommentsByMovieId(int id)
        {
            List<Comment> comments = daoComment.GetCommentsByMovieId(id);

            return comments;
        }
        //RATING
        public double GetRatingByMovieId(int id)
        {
            return daoRating.GetRatingsByMovieId(id);
        }
        /*GET METHODS*/

        /*UPDATE METHODS*/
        //USER
        public void UpdateUser(int id, string login, string password)
        {
            daoUser.UpdateUser(id, login, password);
            MessageBox.Show("Your modification has been saved", "User updated", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //MOVIE
        public void UpdateMovie(int id, string title, string genre, string summary, User user)
        {
            daoMovie.UpdateMovie(id, title, genre, summary, user);
            MessageBox.Show("Your modification has been saved", "User updated", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /*UPDATE METHODS*/

        /*DELETE METHODS*/
        //MOVIE
        public void DeleteMovie(string title)
        {
            Movie movie = daoMovie.GetMovieByTitle(title);
            int movieId = movie.Id;
            daoMovie.DeleteMovie(movieId);
            MessageBox.Show("Your movie has been succesfully delete", "Movie deleted", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        /*DELETE METHODS*/

        /*OTHER METHODS*/
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
                MessageBox.Show("Welcome !", "Information correct", MessageBoxButton.OK, MessageBoxImage.Information);
                return user2.Id;
            }
        }
        /*OTHER METHODS*/
    }
}
