using System;
using System.Data;

namespace MovieNetDB
{
    public class MovieController : DataModelContainer
    {
        private IMovieRepository _movieRepository;

        public MovieController()
        {
            this._movieRepository = new MovieRepository(new DataModelContainer());
        }

        public MovieController(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        public void DisplayAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Id + " " + movie.Title);
            }
        }
        
        public void CreateMovie(Movie movie)
        {
            if (movie != null)
            {
                _movieRepository.InsertMovie(movie);
                _movieRepository.SaveMovie();
            }
        }
        
        public void EditMovie(Movie movie)
        {
            if (movie != null)
            {
                _movieRepository.UpdateMovie(movie);
                _movieRepository.SaveMovie();
            }
        }
        
        public void DeleteMovie(int Id)
        {
            var movie = _movieRepository.GetMovieById(Id);
            _movieRepository.DeleteMovie(Id);
            _movieRepository.SaveMovie();
        }

    }
}