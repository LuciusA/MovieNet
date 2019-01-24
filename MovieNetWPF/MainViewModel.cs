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
            Name = "Hello MVVM !";
            MyCommand = new RelayCommand(MyCommandExecute);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand MyCommand { get; }

        void MyCommandExecute()
        {
            Name = "Hello Click!";
        }
    }
}
