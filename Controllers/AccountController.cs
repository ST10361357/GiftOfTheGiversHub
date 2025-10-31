using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using System.Threading.Tasks;

namespace GiftOfTheGiversHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Register page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register process
        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail);

                if (existingUser != null)
                {
                    ModelState.AddModelError("UserEmail", "Email already registered.");
                    return View(model);
                }

                // Hash password
                var hasher = new PasswordHasher<User>();
                string hashedPassword = hasher.HashPassword(null, model.Password);

                // Create new user
                var user = new User
                {
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Role = model.Role,
                    Password = hashedPassword
                };

                // Save to database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Redirect to login
                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: Login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login process
        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail);

                if (user != null)
                {
                    var hasher = new PasswordHasher<User>();
                    var result = hasher.VerifyHashedPassword(user, user.Password, model.Password);

                    if (result == PasswordVerificationResult.Success)
                    {
                        // Redirect based on role
                        switch (user.Role)
                        {
                            case "Admin":
                                return RedirectToAction("Dashboard", "Admin");

                            case "Donor":
                                return RedirectToAction("DonorHome", "Donor");

                            case "Volunteer":
                                return RedirectToAction("VolunteerHome", "Volunteer");

                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                }

                ModelState.AddModelError("", "Login unsuccessful. Please try again.");
                Console.WriteLine("Login POST triggered");

            }

            return View(model);
        }
    }
}

