using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGiversHub.Controllers
{
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Donor
        public async Task<IActionResult> Donor()
        {
            var model = new DonorPageViewModel
            {
                DonatorList = await _context.Donators.ToListAsync()
            };
            return View(model);
        }
        // POST: Donor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonorPageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.DonatorList = await _context.Donators.ToListAsync();
                return View("Donor", viewModel);
            }

            _context.Donators.Add(viewModel.NewDonator);
            await _context.SaveChangesAsync();

            return RedirectToAction("Donor");
        }

        // GET: My Contributions (donations to incidents)
        public async Task<IActionResult> MyContributions()
        {
            var email = User.Identity?.Name;

            var incidents = await _context.Incidents
                .Where(i => i.AssignedDonatorEmail == email)
                .ToListAsync();

            return View(incidents);
        }

    }
}
