using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public interface IDAOMovie
    {
        Movie GetMovieById(int movieId);
        List<Movie> GetMovies();
        void CreateMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int idmovieId);
        Movie CheckIfExist(string title);
    }
}
