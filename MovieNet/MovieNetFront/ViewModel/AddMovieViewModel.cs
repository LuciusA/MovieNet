﻿using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MovieNetFront.ViewModel
{
    class AddMovieViewModel : BindableBase
    {
        public AddMovieViewModel(int id)
        {
            _userId = id;
            AddGenreToSelect();
            NavCommand = new MyICommand<string>(OnNav);
            AddMovieCommand = new MyICommand<string>(AddMovie);
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        public MyICommand<string> AddMovieCommand { get; private set; }

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

        private void OnNav(string destination)
        {
            UserHomeViewModel userHomeViewModel = new UserHomeViewModel(_userId);
            switch (destination)
            {
                case "userHome":
                    CurrentViewModel = userHomeViewModel;
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

        private double _rating;
        public double Rating
        {
            get => _rating;
            set
            {
                _rating = value;
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

        private void AddMovie(string obj)
        {
            if (!string.IsNullOrEmpty(_title) && !string.IsNullOrEmpty(_selectedGenre) && !string.IsNullOrEmpty(_summary))
            {
                User user = ServiceFacade.GetUserById(_userId);
                ServiceFacade.CreateMovie(_title, _selectedGenre, _summary, _rating, user);
                OnNav("userHome");
            }
            else
                MessageBox.Show("Error you have to fill all the fields", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
