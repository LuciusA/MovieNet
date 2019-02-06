using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieNetFront.ViewModel
{
    class MovieDetailViewModel : BindableBase
    {
        public MovieDetailViewModel(int userId, int movieId)
        {
            Console.WriteLine("C'est le movieid :" + movieId);
            _userId = userId;
            _movieId = movieId;
            NavCommand = new MyICommand<string>(OnNav);
            AddCommentCommand = new MyICommand<string>(AddComment);
            commentList = new CollectionViewSource();
            commentList.Source = GetCommentsByMovieId(_movieId);
            commentList.Filter += commentList_Filter;
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;
        
        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

        public MyICommand<string> AddCommentCommand { get; private set; }

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

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
            }
        }

        private CollectionViewSource commentList;

        private void OnNav(string destination)
        {
            UserHomeViewModel userHomeViewModel = new UserHomeViewModel(_userId);
            MovieDetailViewModel movieDetailViewModel = new MovieDetailViewModel(_userId, _movieId);
            switch (destination)
            {
                case "userHome":
                    CurrentViewModel = userHomeViewModel;
                    break;
                case "detailMovie":
                    break;
                case "current":
                    CurrentViewModel = movieDetailViewModel;
                    break;
                default:
                    CurrentViewModel = CurrentViewModel;
                    break;
            }
        }

        private List<Comment> GetCommentsByMovieId(int movieId)
        {
            List<Comment> comments = ServiceFacade.GetCommentsByMovieId(movieId);
            return comments;
        }

        private void AddComment(string obj)
        {
            Console.WriteLine("Comment:" + _comment);

            if (!string.IsNullOrEmpty(_comment))
            {
                User user = ServiceFacade.GetUserById(_userId);
                Movie movie = ServiceFacade.GetMovieById(_movieId);
                ServiceFacade.CreateComment(_comment, user, movie);
                MessageBox.Show("Comment added", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                OnNav("current");
            }
            else
                MessageBox.Show("Error you have to fill all the fields", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
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
                return this.commentList.View;
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
                this.commentList.View.Refresh();
                //RaisePropertyChanged("FilterText");
            }
        }

        void commentList_Filter(object sender, FilterEventArgs e)
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
