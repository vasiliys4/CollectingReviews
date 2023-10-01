namespace CollectingReviews.Models
{
    public interface IRepository
    {
        Task<Review> GetReview (Guid id);
        Task<List<Review>> GetAll();
        Task CreateReview(Review review);
        Task UpdateReview (Review review);
        Task DeleteReview(Guid id);

    }
}
