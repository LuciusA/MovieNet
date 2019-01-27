using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieNetDB
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DataModelContainer context;

        public UserRepository(DataModelContainer context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.UserSet.ToList();
        }

        public User GetUserById(int id)
        {
            return context.UserSet.Find(id);
        }

        public void CreateUser(User user)
        {
            context.UserSet.Add(user);
        }

        public void DeleteUser(int userId)
        {
            User user = context.UserSet.Find(userId);
            context.UserSet.Remove(user);
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void SaveUser()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}