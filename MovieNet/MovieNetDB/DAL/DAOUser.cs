using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public class DAOUser : IDAOUser
    {
        private DataModelContainer context;

        public DAOUser(DataModelContainer context)
        {
            this.context = context;
        }

        public List<User> GetUsers()
        {
            return context.UserSet.ToList();
        }

        public User GetUserById(int id)
        {
            return context.UserSet.Find(id);
        }

        public void CreateUser(User user)
        {
            Console.WriteLine("userDAO");
            context.UserSet.Add(user);
            context.SaveChanges();
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
