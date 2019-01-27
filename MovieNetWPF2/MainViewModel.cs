using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNetDB;

namespace MovieNetWPF
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //Name = "Hello MVVM !";
            MyCommand = new RelayCommand(MyCommandExecute);
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand MyCommand { get; }

        void MyCommandExecute()
        {
            Console.WriteLine("Username:" + _username);
            Console.WriteLine("Password:" + _password);
            User user = new User();
            UserController userCtrl = new UserController();
            user.Username = _username;
            user.Password = _password;
            Console.WriteLine("Username1: " + user.Username);
            Console.WriteLine("Password1: " + user.Password);
            userCtrl.CreateUser(user);
            //RaisePropertyChanged();
        }
    }
}
