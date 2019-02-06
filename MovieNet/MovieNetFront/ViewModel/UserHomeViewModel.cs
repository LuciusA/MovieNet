using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieNetFront.ViewModel
{
    class UserHomeViewModel : BindableBase
    {
        public UserHomeViewModel(int id)
        {
            _userId = id;
            addMovieViewModel = new AddMovieViewModel(_userId);
            NavCommand = new MyICommand<string>(OnNav);
            GetTitleMovieCommand = new MyICommand<string>(GetMovieTitle);
            movieList = new CollectionViewSource();
            movieList.Source = GetMovieList();
            movieList.Filter += movieList_Filter;
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        private AddMovieViewModel addMovieViewModel;

        private MovieDetailViewModel movieDetailViewModel;

        private UserAccountViewModel userAccountViewModel;

        private UserMoviesViewModel userMoviesViewModel;

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

        public MyICommand<string> GetTitleMovieCommand { get; private set; }

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
                case "addMovie":
                    CurrentViewModel = addMovieViewModel;
                    break;
                case "detailMovie":
                    movieDetailViewModel = new MovieDetailViewModel(_userId, _movieId);
                    CurrentViewModel = movieDetailViewModel;
                    break;
                case "editAccount":
                    userAccountViewModel = new UserAccountViewModel(_userId);
                    CurrentViewModel = userAccountViewModel;
                    break;
                case "userMovies":
                    userMoviesViewModel = new UserMoviesViewModel(_userId, _movieId);
                    CurrentViewModel = userMoviesViewModel;
                    break;
                default:
                    CurrentViewModel = CurrentViewModel;
                    break;
            }
        }

        private void GetMovieTitle(string title)
        {
            Movie movie = ServiceFacade.GetMovieByTitle(title);
            _movieId = movie.Id;
            OnNav("detailMovie");
        }

        private List<Movie> GetMovieList()
        {
            List<Movie> movies = ServiceFacade.GetAllMovies();
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

        /*public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }*/
    }
}
