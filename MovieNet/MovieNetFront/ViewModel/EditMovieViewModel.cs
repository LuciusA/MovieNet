using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieNetFront.ViewModel
{
    class EditMovieViewModel : BindableBase
    {
        public EditMovieViewModel(int userId, int movieId)
        {
            Console.WriteLine("1 erTest du movieid :" + movieId);
            _userId = userId;
            _movieId = movieId;
            AddGenreToSelect();
            NavCommand = new MyICommand<string>(OnNav);
            EditMovieCommand = new MyICommand<string>(EditMovie);
            Console.WriteLine("Test du movieid :" + _movieId);
            Movie movie = GetMovie(_movieId);
            _title = movie.Title;
            _selectedGenre = movie.Genre;
            _summary = movie.Summary;
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        public MyICommand<string> EditMovieCommand { get; private set; }

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

        private void OnNav(string destination)
        {
            UserMoviesViewModel userMoviesViewModel = new UserMoviesViewModel(_userId, _movieId);
            switch (destination)
            {
                case "userMovies":
                    CurrentViewModel = userMoviesViewModel;
                    break;
                default:
                    break;
            }
        }
        public void AddGenreToSelect()
        {
            Genres = new ObservableCollection<string>();
            Genres.Add("Action");
            Genres.Add("Adventure");
            Genres.Add("Comedy");
            Genres.Add("Crime / Gangster");
            Genres.Add("Drama");
            Genres.Add("Epics / Historical");
            Genres.Add("Horror");
            Genres.Add("Musicals / Dance");
            Genres.Add("Science Fiction");
            Genres.Add("War");
            Genres.Add("Western");
        }

        public ObservableCollection<string> Genres { get; set; }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

        private string _selectedGenre;
        public string SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
            }
        }

        private string _summary;
        public string Summary
        {
            get => _summary;
            set
            {
                _summary = value;
            }
        }

        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
            }
        }

        private int _movieId;
        public int MovieId
        {
            get => _movieId;
            set
            {
                _movieId = value;
            }
        }

        public Movie GetMovie(int movieId)
        {
            Movie movie = ServiceFacade.GetMovieById(movieId);
            return movie;
        }

        private void EditMovie(string obj)
        {
            Console.WriteLine("Title:" + _title);
            Console.WriteLine("Genre:" + _selectedGenre);
            Console.WriteLine("Summary:" + _summary);
            Console.WriteLine("UserId:" + _userId);

            if (!string.IsNullOrEmpty(_title) && !string.IsNullOrEmpty(_selectedGenre) && !string.IsNullOrEmpty(_summary))
            {
                User user = ServiceFacade.GetUserById(_userId);
                ServiceFacade.UpdateMovie(_movieId, _title, _selectedGenre, _summary, user);
                OnNav("userMovies");
            }
            else
                MessageBox.Show("Error you have to fill all the fields", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
