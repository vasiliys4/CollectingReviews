using CollectingReviews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollectingReviews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IRepository repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var reviews = await repository.GetAll();
            return View(reviews);
        }
    }
}