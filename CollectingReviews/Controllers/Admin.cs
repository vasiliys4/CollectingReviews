using CollectingReviews.Models;
using CollectingReviews.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectingReviews.Controllers
{
    //[Authorize(Roles ="admin")]
    public class Admin : Controller
    {
        readonly IRepository repository;
        readonly UserManager<UserForDB> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public Admin(IRepository repository, UserManager<UserForDB> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var review = await repository.GetAll();
            if (review == null)
            {
                Redirect("Home/Index");
            }
            return View(review);
        }
        public async Task DeleteReview(Guid id)
        {
            await repository.delete(id);
        }
        [HttpGet]
        public IActionResult GetUsers() => View(_userManager.Users.ToList());
        [HttpGet]
        public IActionResult GetRole() => View(_roleManager.Roles.ToList());
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(name);
        }
        [HttpGet]
        public IActionResult UserList() => View(_userManager.Users.ToList());
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}
