using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNetWPF.Views;
using MovieNetWPF.ViewModel;

namespace MovieNetWPF
{
    class MainViewModel : BindableBase
    {

        public MainViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private RegisterUserViewModel registerUserViewModel = new RegisterUserViewModel();

        //private OrderViewModel orderViewModelModel = new OrderViewModel();

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
                    CurrentViewModel = registerUserViewModel;
                    break;
                //case "customers":
                default:
                    //CurrentViewModel = custListViewModel;
                    break;
            }
        }

        /*public MainViewModel()
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
            Console.WriteLine("Password:" + _password);*/
        /*User user = new User();
        UserController userCtrl = new UserController();
        user.Username = _username;
        user.Password = _password;
        Console.WriteLine("Username1: " + user.Username);
        Console.WriteLine("Password1: " + user.Password);
        userCtrl.CreateUser(user);*/
        //RaisePropertyChanged();
        //}
    }
}
