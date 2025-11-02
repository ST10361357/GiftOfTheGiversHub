using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GiftOfTheGiversHub.Controllers
{
    public class IncidentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncidentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Report Incident Page
        [HttpGet]
        public async Task<IActionResult> ReportIncident()
        {
            var model = new IncidentPageViewModel
            {
                NewIncident = new IncidentModel
                {
                    DateReported = DateTime.Now
                },
                IncidentList = await _context.Incidents.ToListAsync()
            };

            return View(model);
        }

        // POST: Create New Incident
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncidentPageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IncidentList = await _context.Incidents.ToListAsync();
                return View("ReportIncident", model); // ✅ pass IncidentPageViewModel
            }

            model.NewIncident.DateReported = DateTime.Now;
            model.NewIncident.Status = "Pending";

            _context.Incidents.Add(model.NewIncident);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ReportIncident));
        }

    }
}





