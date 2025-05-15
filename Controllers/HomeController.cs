using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AgriEnergyConnect.Controllers
{
    public class HomeController: Controller
    {
        private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //  this code is here to check if user is logged in
            var username = HttpContext.Session.GetString("username");
                var role = HttpContext.Session.GetString("role");

            if (username == null)
            {
                // this code redirects to the login if not logged in
                return RedirectToAction("Login", "Auth");
            }

            // this is here to pass the user info to the view page
           ViewBag.Username = username;
            ViewBag.Role = role;

            return View();
        }

       public IActionResult Privacy()
        {
             return View();
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]//my code with AI editting
       public IActionResult Error()
        {
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
