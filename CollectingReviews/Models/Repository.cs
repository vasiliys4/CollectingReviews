using CollectingReviews.Data;
using Microsoft.EntityFrameworkCore;

namespace CollectingReviews.Models
{
    public class Repository : IRepository
    {
        readonly ApplicationDBContext _dbContext;
        public Repository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateReview(Review review)
        {
            await _dbContext.AddAsync(review);
            await _dbContext.SaveChangesAsync();
        }

        public async Task delete(Guid id)
        {
            var review = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Reviews.Remove(review);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Review> get(Guid id)
        {
            return await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Review>> GetAll()
        {
            return await _dbContext.Reviews.ToListAsync();
        }

        public async Task update(Review review)
        {
            var existingReview = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == review.Id);
            existingReview = review;
            await _dbContext.SaveChangesAsync();
        }
    }
}
