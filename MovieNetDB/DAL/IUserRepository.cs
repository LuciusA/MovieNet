using System;
using System.Collections.Generic;

namespace MovieNetDB
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int Id);
        void CreateUser(User obj);
        void UpdateUser(User obj);
        void DeleteUser(int Id);
        void SaveUser();
    }
}