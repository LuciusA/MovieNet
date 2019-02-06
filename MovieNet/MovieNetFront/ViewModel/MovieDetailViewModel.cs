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
            AddRatingCommand = new MyICommand<string>(AddRating);
            commentList = new CollectionViewSource();
            commentList.Source = GetCommentsByMovieId(_movieId);
            commentList.Filter += commentList_Filter;
            GetMovieById(_movieId);
            GetRatingByMovieId(_movieId);
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

        public MyICommand<string> AddRatingCommand { get; private set; }

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

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }

        private string _genre;
        public string Genre
        {
            get => _genre;
            set
            {
                _genre = value;
            }
        }

        private double _rating;
        public double Rating
        {
            get => _rating;
            set
            {
                _rating = value;
            }
        }

        private double _userRating;
        public double UserRating
        {
            get => _userRating;
            set
            {
                _userRating = value;
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

        private double GetRatingByMovieId(int movieId)
        {
            double rating = ServiceFacade.GetRatingByMovieId(movieId);
            _rating = Math.Round(rating, 2);
            return rating;
        }

        private Movie GetMovieById(int movieId)
        {
            Movie movie = ServiceFacade.GetMovieById(movieId);
            _title = movie.Title;
            _genre = movie.Genre;
            //_rating = movie.Rating;
            return movie;
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

        private void AddRating(string obj)
        {
            Console.WriteLine("Rating:" + _userRating);

            if (!double.IsNaN(_rating))
            {
                User user = ServiceFacade.GetUserById(_userId);
                Movie movie = ServiceFacade.GetMovieById(_movieId);
                ServiceFacade.CreateRating(_userRating, user, movie);
                MessageBox.Show("Rating added", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
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

            Comment comment = e.Item as Comment;
            if (comment.User.Login.ToUpper().Contains(FilterText.ToUpper()))
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
