using GiftOfTheGiversHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GiftOfTheGiversHub.Controllers
{
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
                var currentUserEmail = User.Identity.Name;
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == currentUserEmail);

                if (currentUser == null || currentUser.Role != "Admin")
                {
                    return Unauthorized();
                }

                var staff = await _context.Users
                    .Where(u => u.Role != "Admin")
                    .ToListAsync();

                return View(staff);
            }

            // POST: Assign Role
            [HttpPost]
            public async Task<IActionResult> AssignRole(int userId, string newRole)
            {
                var currentUserEmail = User.Identity.Name;
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserEmail == currentUserEmail);

                if (currentUser == null || currentUser.Role != "Admin")
                {
                    return Unauthorized();
                }

                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }

                var oldRole = user.Role;
                user.Role = newRole;

                // Log the change
                var log = new RoleChangeLog
                {
                    UserId = userId,
                    OldRole = oldRole,
                    NewRole = newRole,
                    ChangedBy = currentUser.UserEmail,
                    Timestamp = DateTime.UtcNow
                };

                _context.RoleChangeLogs.Add(log);
                await _context.SaveChangesAsync();

                return RedirectToAction("Dashboard");
            }
        }
    }


