using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetFront.ViewModel
{
    class RegisterViewModel : BindableBase
    {
        public RegisterViewModel()
        {
            LoginCommand = new MyICommand<string>(Login);
        }

        public MyICommand<string> LoginCommand { get; private set; }

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

        private void Login(string obj)
        {
            Console.WriteLine("Login:" + _username);
            Console.WriteLine("Password:" + _password);
            Console.WriteLine("ConfirmPassword:" + _confirmPassword);
            ServiceFacade ServiceFacade = ServiceFacade.Instance;
            ServiceFacade.CreateUser(_username, _password);
        }
    }
}
