using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRPractise.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPractise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult CreateUser()
        {

            var result1 = _userManager.CreateAsync(new AppUser { Fullname = "Ali" },"123!QWEasd").Result;
            var result2 = _userManager.CreateAsync(new AppUser { Fullname = "Aqil" }, "123!QWEasd").Result;
            var result3 = _userManager.CreateAsync(new AppUser { Fullname = "Tural" }, "123!QWEasd").Result;
            var result4 = _userManager.CreateAsync(new AppUser { Fullname = "Nursultan" }, "123!QWEasd").Result;
            var result5 = _userManager.CreateAsync(new AppUser { Fullname = "Sahil" }, "123!QWEasd").Result;

            return Ok("Accounts created");
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
