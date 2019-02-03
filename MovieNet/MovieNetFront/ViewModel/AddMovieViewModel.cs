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
        public AddMovieViewModel()
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

        private string _selectedGenre;
        public string SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
            }
        }
    }
}
