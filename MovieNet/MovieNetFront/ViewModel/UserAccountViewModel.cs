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
    class UserAccountViewModel : BindableBase
    {
        public UserAccountViewModel(int userId)
        {
            _userId = userId;
            NavCommand = new MyICommand<string>(OnNav);
            EditAccountCommand = new MyICommand<string>(EditAccount);
            User user = GetUser(_userId);
            _username = user.Login;
            _password = user.Password;
        }

        ServiceFacade ServiceFacade = ServiceFacade.Instance;

        public MyICommand<string> EditAccountCommand { get; private set; }

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
                case "home":
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
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

        public User GetUser(int userId)
        {
            User user = ServiceFacade.GetUserById(userId);
            return user;
        }

        private void EditAccount(string obj)
        {
            if (string.IsNullOrEmpty(_username) != true && string.IsNullOrEmpty(_password) != true && string.IsNullOrEmpty(_confirmPassword) != true)
            {
                if (_password == _confirmPassword)
                {
                    ServiceFacade.UpdateUser(_userId, _username, _password);
                    OnNav("home");
                }
                else
                    MessageBox.Show("Error your passwords don't match", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Error you have to fill all the fields", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
