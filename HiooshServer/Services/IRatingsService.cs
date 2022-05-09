using HiooshServer.Models;

namespace HiooshServer.Services
{
    public interface IRatingsService
    {
        List<Rating> GetAllRating();
        Rating? GetRating(int? id);
        void AddRating(Rating rating);
        void UpdateRating(int id, int NumberRating, string StringRating);

        void DeleteRating(int id);
    }
}