using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using AgriEnergyConnect.Models;

public class AuthController : Controller
{
    private readonly AgriConnectDbContext _context;

    public AuthController(AgriConnectDbContext context)
    {
        _context = context;
    }

    // this is to show the login form
        public IActionResult Login()
    {
        return View();
    }

    // this is to handle login POST request
            [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // this is here to try and find a matching user in the database
       var user = _context.SystemUser.SingleOrDefault(u => u.username == username && u.Password == password);

       if (user != null)
        {
            // this is here to save user info to session
            HttpContext.Session.SetString("Username", user.username);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "Home");
        }


        // this is here to show error if login fails
        ViewBag.Error = "it is an invalid username or password.";
        return View();
    }


    // this is to log out the user and clear session
         public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
