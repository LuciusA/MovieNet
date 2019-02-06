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
        Movie GetMovieByTitle(string title);
        List<Movie> GetMovies();
        List<Movie> GetMoviesByUserId(int userId);
        void CreateMovie(Movie movie);
        void UpdateMovie(int id, string title, string genre, string summary, User user);
        void DeleteMovie(int idmovieId);
        Movie CheckIfExist(string title);
    }
}
