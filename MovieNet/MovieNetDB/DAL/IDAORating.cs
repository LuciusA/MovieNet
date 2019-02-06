using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public interface IDAORating
    {
        void CreateRating(Rating rating);
        void UpdateRating(Rating rating);
        Rating GetRatingById(int ratingId);
        double GetRatingsByMovieId(int movieId);
        List<Rating> GetRatingsByUserId(int userId);
        void DeleteRating(int ratingId);
    }
}
