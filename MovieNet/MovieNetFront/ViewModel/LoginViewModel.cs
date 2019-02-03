using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieNetFront.ViewModel
{
    class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            LoginCommand = new MyICommand<string>(Login);
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        AddMovieViewModel addMovieViewModel = new AddMovieViewModel();

        public MyICommand<string> LoginCommand { get; private set; }

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; set; }

        private void OnNav(string destination)
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            switch (destination)
            {
                case "home":
                    CurrentViewModel = homeViewModel;
                    break;
                default:
                    break;
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

        private void Login(string obj)
        {
            Console.WriteLine("Login:" + _username);
            Console.WriteLine("Password:" + _password);

            if (string.IsNullOrEmpty(_username) != true && string.IsNullOrEmpty(_password) != true)
            {
                ServiceFacade.LoginUser(_username, _password);
                CurrentViewModel = addMovieViewModel;
            }
            else
                MessageBox.Show("Error you have to fill all the fields", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
