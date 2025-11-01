using GiftOfTheGiversHub.Data;
using Microsoft.AspNetCore.Mvc;
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

        // GET: Volunteer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volunteer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.Role = "Volunteer"; // ✅ Assign role
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard", "Admin");
        }
    }
}