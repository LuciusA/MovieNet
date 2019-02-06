using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    public interface IDAORating
    {
        Rating GetRatingById(int ratingId);
        double GetRatingsByMovieId(int movieId);
        List<Rating> GetRatingsByUserId(int userId);
        void CreateRating(Rating rating);
        void UpdateRating(Rating rating);
        void DeleteRating(int ratingId);
    }
}
