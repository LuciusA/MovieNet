using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

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

        public RelayCommand MyCommand { get; }

        void MyCommandExecute()
        {
            Console.WriteLine("Username:" + _username);
            Console.WriteLine("Username:" + Username);
        }
    }
}
