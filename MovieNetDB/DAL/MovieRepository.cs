using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace MovieNetDB
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private DataModelContainer context;

        public MovieRepository(DataModelContainer context)
        {
            this.context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return context.MovieSet.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return context.MovieSet.Find(id);
        }

        public void InsertMovie(Movie movie)
        {
            context.MovieSet.Add(movie);
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