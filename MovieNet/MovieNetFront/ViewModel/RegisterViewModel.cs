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
    class RegisterViewModel : BindableBase
    {
        public RegisterViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            RegisterCommand = new MyICommand<string>(Register);
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        public MyICommand<string> RegisterCommand { get; private set; }

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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
            }
        }

        private void Register(string obj)
        {
            Console.WriteLine("Login:" + _username);
            Console.WriteLine("Password:" + _password);
            Console.WriteLine("ConfirmPassword:" + _confirmPassword);
       
            if (string.IsNullOrEmpty(_username) != true && string.IsNullOrEmpty(_password) != true && string.IsNullOrEmpty(_confirmPassword) != true)
            {
                if (_password == _confirmPassword)
                    ServiceFacade.CreateUser(_username, _password);
                else
                    MessageBox.Show("Error your passwords don't match", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Error you have to fill all the fields", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
