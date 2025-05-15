using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

public class AuthController : Controller
{
    private readonly AgriConnectDbContext _context;

    public AuthController(AgriConnectDbContext context)
    {
        _context = context;
    }

    // Show the login form
    public IActionResult Login()
    {
        return View();
    }

    // Handle login POST request
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Try to find a matching user in the database
        var user = _context.SystemUsers.SingleOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            // Save user info to session
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "Home");
        }

        // Show error if login fails
        ViewBag.Error = "Invalid username or password.";
        return View();
    }

    // Log out the user and clear session
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
