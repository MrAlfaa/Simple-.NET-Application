using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PurchaseRequestApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Create", "PurchaseRequest");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
    }
}
