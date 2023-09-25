using Microsoft.EntityFrameworkCore;
using CollectingReviews.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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
