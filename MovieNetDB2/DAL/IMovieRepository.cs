using System;
using System.Collections.Generic;

namespace MovieNetDB
{
    public interface IMovieRepository : IDisposable
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int Id);
        void InsertMovie(Movie obj);
        void UpdateMovie(Movie obj);
        void DeleteMovie(int Id);
        void SaveMovie();
    }
}