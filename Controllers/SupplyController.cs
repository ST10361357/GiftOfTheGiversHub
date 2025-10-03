using GiftOfTheGiversHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SupplyController : Controller
{
    private readonly ApplicationDbContext _context;

    public SupplyController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Projects = new SelectList(_context.Projects, "ProjectId", "ProjectName");
        ViewBag.Donations = new SelectList(_context.Supplies, "DonationId", "DonationId"); // Adjust if Donation has a name
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SupplyModel model)
    {
        if (ModelState.IsValid)
        {
            var supply = new SupplyModel
            {
                ProjectId = model.ProjectId,
                DonationId = model.DonationId,
                ItemName = model.ItemName,
                Quantity = model.Quantity,
                SupplyStatus = model.SupplyStatus,
                DeliveryDate = model.DeliveryDate
            };

            _context.Supplies.Add(supply);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Projects = new SelectList(_context.Projects, "ProjectId", "ProjectName");
        ViewBag.Donations = new SelectList(_context.Donations, "DonationId", "DonationId");
        return View(model);
    }
}

