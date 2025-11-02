using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace GiftOfTheGiversHub.Controllers
{


    public class VolunteerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VolunteerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Volunteer
        public async Task<IActionResult> Volunteer()
        {
            var model = new VolunteerPageViewModel
            {
                VolunteerList = await _context.Volunteers.ToListAsync()
            };
            return View(model);
        }

        // POST: Volunteer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VolunteerPageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.VolunteerList = await _context.Volunteers.ToListAsync();
                return View("Volunteer", viewModel);
            }

            _context.Volunteers.Add(viewModel.NewVolunteer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Volunteer");
        }

        //assigned incidents
        [Authorize(Roles = "Volunteer")]
        public async Task<IActionResult> MyIncidents()
        {
            var email = User.Identity?.Name;

            var incidents = await _context.Incidents
                .Where(i => i.AssignedVolunteerEmail == email)
                .ToListAsync();

            return View(incidents);
        }


    }
}