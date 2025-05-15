using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//some code edited by 
public class HarvestController : Controller
{
    private readonly AgriConnectDbContext _context;
    public HarvestController(AgriConnectDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View(); // this code here loads the Create.cshtml in harvest view 
    }

    [HttpPost]
    public IActionResult Create(HarvestItem item)// my code with AI editing 
    {
        // Simulate assigning to first grower (for testing)
        var grower = _context.Growers.FirstOrDefault();
         if (grower == null)
        {
                    ViewBag.Error = "No grower found.";
            return View();
        }

        item.GrowerId = grower.Id;
        _context.HarvestIteams.Add(item);

                _context.SaveChanges();

        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        var items = _context.HarvestIteams.Include(h => h.Grower).ToList();
        return View(items); // this loads the List.cshtml in harvest views 
    }
}
