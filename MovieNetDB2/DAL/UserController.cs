using System;

namespace MovieNetDB
{
    public class UserController : DataModelContainer
    {
        private IUserRepository _userRepository;

        public UserController()
        {
            this._userRepository = new UserRepository(new DataModelContainer());
        }

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void DisplayAllMovies()
        {
            var users = _userRepository.GetAllUsers();

            foreach (var user in users)
            {
                Console.WriteLine(user.Id + " " + user.Username);
            }
        }

        public void CreateUser(User user)
        {
            if (user != null)
            {
                _userRepository.CreateUser(user);
                _userRepository.SaveUser();
            }
        }

        public void UpdateUser(User user)
        {
            if (user != null)
            {
                _userRepository.UpdateUser(user);
                _userRepository.SaveUser();
            }
        }

        public void DeleteUser(int Id)
        {
            var user = _userRepository.GetUserById(Id);
            _userRepository.DeleteUser(Id);
            _userRepository.SaveUser();
        }

    }
}