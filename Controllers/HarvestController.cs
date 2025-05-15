using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class HarvestController : Controller
{
    private readonly AgriConnectDbContext _context;

    public HarvestController(AgriConnectDbContext context)
    {
        _context = context;
    }

    // GET: Add Harvest Item (Grower only)
    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("Role") != "Grower")
            return Unauthorized();

        return View();
    }

    // POST: Add Harvest Item
    [HttpPost]
    public IActionResult Create(HarvestItem item)
    {
        if (HttpContext.Session.GetString("Role") != "Grower")
            return Unauthorized();

        // For simplicity, use the first grower found
        var grower = _context.Growers.FirstOrDefault();

        if (grower == null)
        {
            ViewBag.Error = "No grower profile found.";
            return View();
        }

        item.GrowerId = grower.Id;

        if (ModelState.IsValid)
        {
            _context.HarvestItems.Add(item);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        return View(item);
    }

    // GET: View & Filter Harvest Items (Employee only)
    public IActionResult List(string category, DateTime? startDate, DateTime? endDate)
    {
        if (HttpContext.Session.GetString("Role") != "Employee")
            return Unauthorized();

        // Get all harvest items with related grower
        var items = _context.HarvestItems.Include(h => h.Grower).AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(category))
            items = items.Where(h => h.Category == category);
        if (startDate.HasValue)
            items = items.Where(h => h.HarvestDate >= startDate.Value);
        if (endDate.HasValue)
            items = items.Where(h => h.HarvestDate <= endDate.Value);

        return View(items.ToList());
    }
}
