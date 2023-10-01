using CollectingReviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectingReviews.Controllers
{
    public class GetReview : Controller
    {
        readonly IRepository repository;

        public GetReview(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var review = await repository.GetReview(id);
            if (review == null)
            {
                Redirect("Home/Index");
            }
            return View(review);
        }
    }
}
