using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public interface IDAOComment
    {
        Comment GetCommentById(int commentId);
        List<Comment> GetCommentsByMovieId(int movieId);
        List<Comment> GetCommentsByUserId(int userId);
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentId);
    }
}
