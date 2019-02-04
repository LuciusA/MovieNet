using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieNetFront.ViewModel
{
    class UserHomeViewModel : BindableBase
    {
        public UserHomeViewModel(int id)
        {
            Console.WriteLine("UserId ; " + id);
            _userId = id;
            addMovieViewModel = new AddMovieViewModel(_userId);
            NavCommand = new MyICommand<string>(OnNav);

            _movieList = GetMovieList();
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        private AddMovieViewModel addMovieViewModel;

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
            }
        }

        private List<Movie> _movieList;
        public List<Movie> MovieList
        {
            get => _movieList;
            set
            {
                _movieList = value;
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "addMovie":
                    CurrentViewModel = addMovieViewModel;
                    break;
                case "login":
                    break;
                default:
                    CurrentViewModel = CurrentViewModel;
                    break;
            }
        }

        private List<Movie> GetMovieList()
        {
            List<Movie> movies = ServiceFacade.GetAllMovies();
                return movies;
        }

        public ICommand SortCommand
        {
            get;
            private set;
        }
    }
}
