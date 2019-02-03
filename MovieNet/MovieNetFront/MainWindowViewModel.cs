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
            CurrentViewModel = homeViewModel;
            //NavCommand = new MyICommand<string>(OnNav);
        }

        private HomeViewModel homeViewModel = new HomeViewModel();

        /*private LoginViewModel loginViewModel = new LoginViewModel();

        private RegisterViewModel registerViewModel = new RegisterViewModel();*/

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        /*public MyICommand<string> NavCommand { get; set; }

        private void OnNav(string destination)
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            switch (destination)
            {
                case "register":
                    CurrentViewModel = registerViewModel;
                    break;
                case "login":
                    CurrentViewModel = loginViewModel;
                    break;
                case "back":
                    CurrentViewModel = mainWindowViewModel;
                    break;
                default:
                    CurrentViewModel = mainWindowViewModel;
                    break;
            }
        }*/
    }
}
