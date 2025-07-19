using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StudentManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _users;
        private readonly SignInManager<IdentityUser> _signIn;

        public AccountController(UserManager<IdentityUser> users,
                                 SignInManager<IdentityUser> signIn)
        {
            _users = users;
            _signIn = signIn;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password)
        {
            if (!ModelState.IsValid) return View();

            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _users.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signIn.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View();
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (!ModelState.IsValid) return View();

            var result = await _signIn.PasswordSignInAsync(email, password, false, false);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
