using GiftOfTheGiversHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class IncidentController : Controller
{
    private readonly ApplicationDbContext _context;

    public IncidentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Projects = new SelectList(_context.Projects, "ProjectId", "ProjectName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Incident model)
    {
        if (ModelState.IsValid)
        {
            model.ReportedDate = DateTime.Now;
            _context.Incidents.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Projects = new SelectList(_context.Projects, "ProjectId", "ProjectName");
        return View(model);
    }
}

