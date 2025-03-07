using Application.Contracts;
using Application.Dots;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult Login( UserDTO  user)
        {
            var result = _userService.LoginAsync(user);
            if (result.Result.Success)
                return RedirectToRoute(new { area = "Admin", controller = "Home", action = "Index" });

            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
