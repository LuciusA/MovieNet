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

        //INIT CONTEXT
        public DAORating(DataModelContainer context)
        {
            this.context = context;
        }

        //CREATE RATING
        public void CreateRating(Rating rating)
        {
            context.RatingSet.Add(rating);
            SaveRating();
        }

        //GET RATING
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

        //UPDATE RATING
        public void UpdateRating(Rating rating)
        {
            context.Entry(rating).State = EntityState.Modified;
        }

        //DELETE RATING
        public void DeleteRating(int ratingId)
        {
            Rating rating = context.RatingSet.Find(ratingId);
            context.RatingSet.Remove(rating);
        }
        
        //SAVE CONTEXT
        public void SaveRating()
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
