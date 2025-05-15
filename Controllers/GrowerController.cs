using Microsoft.AspNetCore.Mvc;

public class GrowerController : Controller
{
    private readonly AgriConnectDbContext _context;
        public GrowerController(AgriConnectDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
      return View(); // this code here loads the Create.cshtml in the grower folder
    }

    [HttpPost]

            public IActionResult Create(Grower grower)
    {
       _context.Growers.Add(grower);
            _context.SaveChanges();
        return RedirectToAction("index", "home");
    }
}
