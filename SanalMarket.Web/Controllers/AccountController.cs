﻿using Microsoft.AspNetCore.Mvc;

namespace SanalMarket.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
