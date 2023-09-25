namespace CollectingReviews.Models
{
    public interface IRepository
    {
        Task<Review> get (Guid id);
        Task<List<Review>> GetAll();
        Task CreateReview(Review review);
        Task update (Review review);
        Task delete(Guid id);

    }
}
