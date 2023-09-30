using CollectingReviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollectingReviews.Controllers
{
    public class AddReviewController : Controller
    {
        readonly IRepository repository;
        public AddReviewController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Review review)
        {
            await repository.CreateReview(review);
            return RedirectToAction("Add");
        }
    }
}
