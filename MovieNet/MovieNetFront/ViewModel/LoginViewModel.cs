using MovieNetDB;
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
            UserHomeViewModel userHomeViewModel = new UserHomeViewModel(_userId);
            switch (destination)
            {
                case "home":
                    CurrentViewModel = homeViewModel;
                    break;
                case "userHome":
                    CurrentViewModel = userHomeViewModel;
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

        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
            }
        }

        private void Login(string obj)
        {
            Console.WriteLine("Login:" + _username);
            Console.WriteLine("Password:" + _password);

            if (string.IsNullOrEmpty(_username) != true && string.IsNullOrEmpty(_password) != true)
            {
                int userId = ServiceFacade.LoginUser(_username, _password);
                if (userId != 0)
                {
                    _userId = userId;
                    OnNav("userHome");
                }
            }
            else
                MessageBox.Show("Error you have to fill all the fields", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
