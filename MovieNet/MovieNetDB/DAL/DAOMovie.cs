using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    class DAOMovie : IDAOMovie
    {
        private DataModelContainer context;

        //INIT CONTEXT
        public DAOMovie(DataModelContainer context)
        {
            this.context = context;
        }

        //CREATE MOVIE
        public void CreateMovie(Movie movie)
        {
            context.MovieSet.Add(movie);
            SaveMovie();
        }

        //GET MOVIE
        public List<Movie> GetMovies()
        {
            return context.MovieSet.ToList();
        }

        public List<Movie> GetMoviesByUserId(int userId)
        {
            return context.MovieSet.Where(u => u.User.Id == userId).ToList();
        }

        public Movie GetMovieById(int movieId)
        {
            return context.MovieSet.Find(movieId);
        }

        public Movie GetMovieByTitle(string title)
        {
            return context.MovieSet.FirstOrDefault((u => u.Title == title));
        }

        //UPDATE MOVIE
        public void UpdateMovie(int id, string title, string genre, string summary, User user)
        {
            var query = context.MovieSet.FirstOrDefault(u => u.Id == id);
            query.Title = title;
            query.Genre = genre;
            query.Summary = summary;
            SaveMovie();
        }

        // DELETE MOVIE
        public void DeleteMovie(int movieId)
        {
            Movie movie = context.MovieSet.Find(movieId);
            List<Rating> ratings = context.RatingSet.Where(r => r.Movie.Id == movieId).ToList();
            foreach (Rating rating in ratings)
            {
                context.RatingSet.Remove(rating);
            }
            context.MovieSet.Remove(movie);
            SaveMovie();
        }

        public Movie CheckIfExist(string title)
        {
            return context.MovieSet.FirstOrDefault((u => u.Title == title));
        }

        //SAVE CONTEXT
        public void SaveMovie()
        {
            context.SaveChanges();
        }

        //DELETE OBJECT
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
