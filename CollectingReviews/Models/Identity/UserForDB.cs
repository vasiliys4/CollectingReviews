using Microsoft.AspNetCore.Identity;

namespace CollectingReviews.Models
{
    public class UserForDB : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
