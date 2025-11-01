using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGiversHub.Controllers
{
    public class DonorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Donor()
        {
            return View();
        }

        // POST: Donor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonatorModel donor)
        {
            if (!ModelState.IsValid)
            {
                return View(donor);
            }

            _context.Donators.Add(donor);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Admin");
        }
    }
}
