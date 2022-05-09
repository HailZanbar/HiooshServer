using HiooshServer.Models;

namespace HiooshServer.Services
{
    public class RatingService : IRatingsService
    {
        private static List<Rating> ratings = new List<Rating>();
        public List<Rating> GetAllRating()
        {
            return ratings;
        }

        public Rating? GetRating(int? id)
        {
            if(id == null)
            {
                return null;
            }
            return ratings.Find(x => x.Id == id);
        }

        public void AddRating(Rating rating)
        {
            ratings.Add(rating);
        }

        public void UpdateRating(int id, int NumberRating, string StringRating)
        {
            Rating rating = GetRating(id);
            rating.StringRating = StringRating;
            rating.NumberRating = NumberRating;
            rating.Date = DateTime.Now.ToString("MM/dd/yyyy");

        }

        public void DeleteRating(int id)
        {
            ratings.Remove(GetRating(id));
        }
    }
}
