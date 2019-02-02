using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovieNetFront.Views;
using MovieNetFront.ViewModel;
using MovieNetDB;

namespace MovieNetFront
{
    class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private LoginViewModel loginViewModel = new LoginViewModel();

        private RegisterViewModel registerViewModel = new RegisterViewModel();

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "register":
                    CurrentViewModel = registerViewModel;
                    break;
                case "login":
                    CurrentViewModel = loginViewModel;
                    break;
                case "back":
                    CurrentViewModel = CurrentViewModel;
                    break;
                default:
                    CurrentViewModel = CurrentViewModel;
                    break;
            }
        }
    }
}
