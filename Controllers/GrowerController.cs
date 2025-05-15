using Microsoft.AspNetCore.Mvc;

public class GrowerController : Controller
{
    private readonly AgriConnectDbContext _context;

    public GrowerController(AgriConnectDbContext context)
    {
        _context = context;
    }

    // GET: Create Grower Form (only for Employee)
    public IActionResult Create()
    {
        // Only allow access if user is an employee
        if (HttpContext.Session.GetString("Role") != "Employee")
            return Unauthorized();

        return View();
    }

    // POST: Create Grower
    [HttpPost]
    public IActionResult Create(Grower grower)
    {
        if (ModelState.IsValid)
        {
            _context.Growers.Add(grower);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        return View(grower);
    }
}
