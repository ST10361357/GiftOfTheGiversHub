using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GiftOfTheGiversHub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var currentUserEmail = User.Identity?.Name;

            var currentUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == currentUserEmail);

            if (currentUser == null || currentUser.Role != "Admin")
            {
                return Unauthorized();
            }

            var allUsers = await _context.Users
                .Select(u => new UserModel
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    UserEmail = u.UserEmail,
                    Role = u.Role
                })
                .ToListAsync();

            var incidents = await _context.Incidents
                .Select(i => new IncidentModel
                {
                    IncidentId = i.IncidentId,
                    ReporterName = i.ReporterName,
                    ReporterEmail = i.ReporterEmail,
                    IncidentType = i.IncidentType,
                    Location = i.Location,
                    Description = i.Description,
                    UrgencyLevel = i.UrgencyLevel,
                    DateReported = i.DateReported,
                    AssignedVolunteerEmail = i.AssignedVolunteerEmail,
                    AssignedDonatorEmail = i.AssignedDonatorEmail,
                    Status = i.Status
                })
                .ToListAsync();

            var donators = await _context.Donators.ToListAsync();

            var model = new AdminDashboardViewModel
            {
                Admins = allUsers.Where(u => u.Role == "Admin").ToList(),
                Staff = allUsers.Where(u => u.Role != "Admin").ToList(),
                Volunteers = allUsers.Where(u => u.Role == "Volunteer").ToList(),
                Incidents = incidents,
                Donators = donators
            };

            return View(model);
        }

        // POST: Assign Role to Staff
        [HttpPost]
        public async Task<IActionResult> AssignRole(int userId, string newRole)
        {
            var currentUserEmail = User.Identity?.Name;

            var currentUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == currentUserEmail);

            if (currentUser == null || currentUser.Role != "Admin")
            {
                return Unauthorized();
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.Role = newRole;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }

        // POST: Assign Volunteer to Incident
        [HttpPost]
        public async Task<IActionResult> AssignVolunteer(int incidentId, string volunteerEmail)
        {
            var currentUserEmail = User.Identity?.Name;

            var currentUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == currentUserEmail);

            if (currentUser == null || currentUser.Role != "Admin")
            {
                return Unauthorized();
            }

            var incident = await _context.Incidents.FindAsync(incidentId);
            if (incident == null)
            {
                return NotFound();
            }

            incident.AssignedVolunteerEmail = volunteerEmail;
            incident.Status = "Assigned";

            _context.Incidents.Update(incident);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }

        //  Assign Donator to Incident
        [HttpPost]
        public async Task<IActionResult> AssignDonator(int incidentId, string donatorEmail)
        {
            var currentUserEmail = User.Identity?.Name;

            var currentUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == currentUserEmail);

            if (currentUser == null || currentUser.Role != "Admin")
            {
                return Unauthorized();
            }

            var incident = await _context.Incidents.FindAsync(incidentId);
            if (incident == null)
            {
                return NotFound();
            }

            incident.AssignedDonatorEmail = donatorEmail;

            _context.Incidents.Update(incident);
            await _context.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }
    }
}
