using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]//reggister process
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //Hashing  password before saving
                var hasher = new PasswordHasher<User>();
                string hashedPassword = hasher.HashPassword(null, model.Password);

                // new User object
                var user = new User
                {
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Role = model.Role,
                    Password = hashedPassword
                };

                // Save to db
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Redirect after successful registration
                return RedirectToAction("Login");
            }

            // If validation fails, return the form with errors
            return View(model);
        }

        // Login process
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInModel model)
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
                        // will try to Set session or authentication cookie
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Login not successfull, try agains ");
            }

            return View(model);
        }

    }
}
