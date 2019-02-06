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

        //INIT CONTEXT
        public DAOUser(DataModelContainer context)
        {
            this.context = context;
        }

        //CREATE USER
        public void CreateUser(User user)
        {
            context.UserSet.Add(user);
            SaveUser();
        }

        //GET USER
        public List<User> GetUsers()
        {
            return context.UserSet.ToList();
        }

        public User GetUserById(int id)
        {
            return context.UserSet.Find(id);
        }

        public User GetUserByLogin(string login)
        {
            return context.UserSet.FirstOrDefault((u => u.Login == login));
        }

        //UPDATE USER
        public void UpdateUser(int id, string login, string password)
        {
            var query = context.UserSet.FirstOrDefault(u => u.Id == id);
            query.Login = login;
            query.Password = password;
            SaveUser();
        }

        //DELETE USER
        public void DeleteUser(int userId)
        {
            User user = context.UserSet.Find(userId);
            context.UserSet.Remove(user);
        }

        public User LoginUser(string login, string password) 
        {
            return context.UserSet.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        //SAVE CONTEXT
        public void SaveUser()
        {
            context.SaveChanges();
        }

        //DELETE OBJECT
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
