using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieNetFront.ViewModel
{
    class UserMoviesViewModel : BindableBase
    {
        public UserMoviesViewModel(int userId, int movieId)
        {
            _userId = userId;
            _movieId = movieId;
            NavCommand = new MyICommand<string>(OnNav);
            DeleteMovieCommand = new MyICommand<string>(DeleteMovie);
            EditMovieCommand = new MyICommand<string>(EditMovie);
            movieList = new CollectionViewSource();
            movieList.Source = GetMoviesByUserId(_userId);
            movieList.Filter += movieList_Filter;
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

        public MyICommand<string> DeleteMovieCommand { get; private set; }

        public MyICommand<string> EditMovieCommand { get; private set; }

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

        private CollectionViewSource movieList;

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "home":
                    UserHomeViewModel userHomeViewModel= new UserHomeViewModel(_userId);
                    CurrentViewModel = userHomeViewModel;
                    break;
                case "editMovie":
                    EditMovieViewModel editMovieViewMovie = new EditMovieViewModel(_userId, _movieId);
                    CurrentViewModel = editMovieViewMovie;
                    break;
                case "current":
                    UserMoviesViewModel userMoviesViewModel= new UserMoviesViewModel(_userId, _movieId);
                    CurrentViewModel = userMoviesViewModel;
                    break;
                default:
                    CurrentViewModel = CurrentViewModel;
                    break;
            }
        }

        private void DeleteMovie(string title)
        {
            ServiceFacade.DeleteMovie(title);
            OnNav("current");
        }

        private void EditMovie(string title)
        {
            Movie movie = ServiceFacade.GetMovieByTitle(title);
            _movieId = movie.Id;
            OnNav("editMovie");
        }

        private List<Movie> GetMoviesByUserId(int userId)
        {
            List<Movie> movies = ServiceFacade.GetMoviesByUserId(userId);
            return movies;
        }

        private string filterText;

        public ICommand SortCommand
        {
            get;
            private set;
        }

        public ICollectionView SourceCollection
        {
            get
            {
                return this.movieList.View;
            }
        }

        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                this.movieList.View.Refresh();
                //RaisePropertyChanged("FilterText");
            }
        }

        void movieList_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Movie movie = e.Item as Movie;
            if (movie.Title.ToUpper().Contains(FilterText.ToUpper()) || movie.Genre.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
        
    }
}
