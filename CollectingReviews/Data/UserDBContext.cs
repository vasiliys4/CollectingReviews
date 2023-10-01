using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CollectingReviews.Models;

namespace CollectingReviews.Data
{
    public class UserDBContext : IdentityDbContext<UserForDB>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
