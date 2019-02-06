using MovieNetDB;
using MovieNetDB.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    class DAOComment : IDAOComment
    {
        private DataModelContainer context;

        //INIT CONTEXT
        public DAOComment(DataModelContainer context)
        {
            this.context = context;
        }

        //CREATE METHODS
        public void CreateComment(Comment comment)
        {
            context.CommentSet.Add(comment);
            SaveComment();
        }

        //GET METHODS
        public List<Comment> GetCommentsByMovieId(int movieId)
        {
            return context.CommentSet.Where(u => u.Movie.Id == movieId).ToList();
        }

        public List<Comment> GetCommentsByUserId(int userId)
        {
            return context.CommentSet.ToList();
        }

        public Comment GetCommentById(int commentId)
        {
            return context.CommentSet.Find(commentId);
        }

        //UPDATE METHODS
        public void UpdateComment(Comment comment)
        {
            context.Entry(comment).State = EntityState.Modified;
        }

        //DELETE METHODS
        public void DeleteComment(int commentId)
        {
            Comment comment = context.CommentSet.Find(commentId);
            context.CommentSet.Remove(comment);
        }

        //SAVE CONTEXT
        public void SaveComment()
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
