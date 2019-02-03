using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetFront.ViewModel
{
    class UserHomeViewModel : BindableBase
    {
        public UserHomeViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private AddMovieViewModel addMovieViewModel = new AddMovieViewModel();

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

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
    }
}
