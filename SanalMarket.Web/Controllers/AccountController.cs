using Microsoft.AspNetCore.Mvc;

namespace SanalMarket.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password, bool remember)
        {
            return null;
        }
    }
}
