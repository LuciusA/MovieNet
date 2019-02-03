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

        public DAOMovie(DataModelContainer context)
        {
            this.context = context;
        }

        public List<Movie> GetMovies()
        {
            return context.MovieSet.ToList();
        }

        public Movie  GetMovieById(int movieId)
        {
            return context.MovieSet.Find(movieId);
        }

        public void CreateMovie(Movie movie)
        {
            context.MovieSet.Add(movie);
            context.SaveChanges();
        }

        public Movie CheckIfExist(string title)
        {
            return context.MovieSet.FirstOrDefault((u => u.Title == title));
        }

        public void DeleteMovie(int movieId)
        {
            Movie movie = context.MovieSet.Find(movieId);
            context.MovieSet.Remove(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
        }

        public void SaveMovie()
        {
            context.SaveChanges();
        }

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
