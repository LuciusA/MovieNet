using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNetDB.DAL
{
    class DAORating : IDAORating
    {
        private DataModelContainer context;

        public DAORating(DataModelContainer context)
        {
            this.context = context;
        }

        public double GetRatingsByMovieId(int movieId)
        {
            var result = context.RatingSet.Where(u => u.Movie.Id == movieId);
            if (result.Any())
                return context.RatingSet.Where(u => u.Movie.Id == movieId).Average(u => u.Rate);
            else
                return 0;
        }

        public List<Rating> GetRatingsByUserId(int userId)
        {
            return context.RatingSet.ToList();
        }

        public Rating GetRatingById(int ratingId)
        {
            return context.RatingSet.Find(ratingId);
        }

        public void CreateRating(Rating rating)
        {
            context.RatingSet.Add(rating);
            context.SaveChanges();
        }

        public void DeleteRating(int ratingId)
        {
            Rating rating = context.RatingSet.Find(ratingId);
            context.RatingSet.Remove(rating);
        }

        public void UpdateRating(Rating rating)
        {
            context.Entry(rating).State = EntityState.Modified;
        }

        public void SaveRating()
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
