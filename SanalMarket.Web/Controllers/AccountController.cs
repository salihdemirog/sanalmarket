using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SanalMarket.Infrastructure.Abstract;
using System.Security.Claims;

namespace SanalMarket.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(string email, string password, bool remember)
        {
            var user =_userService.Login(email,password);
            if(user == null)
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Mail),
                new Claim(ClaimTypes.Email, user.Mail),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrinciple = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync(claimPrinciple,new AuthenticationProperties
            {
                IsPersistent = remember,
            });

            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Product");
        }
    }
}
