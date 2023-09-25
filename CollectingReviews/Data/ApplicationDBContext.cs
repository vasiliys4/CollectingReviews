using CollectingReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectingReviews.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
