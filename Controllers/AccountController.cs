using GiftOfTheGiversHub.Data;
using GiftOfTheGiversHub.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GiftOfTheGiversHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail);

                if (existingUser != null)
                {
                    ModelState.AddModelError("UserEmail", "Email already registered.");
                    return View(model);
                }

                var hasher = new PasswordHasher<User>();
                model.Password = hasher.HashPassword(null, model.Password);

                _context.Users.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: Login
        [HttpGet] 
        public IActionResult Login()
        { 
            return View(); 
        } 
        
        // POST: Login

        [HttpPost]
        public async Task<IActionResult> Login(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid login data.");
                return View(model);
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == model.UserEmail);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(model);
            }

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.Password, model.Password);

            if (result != PasswordVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect password.");
                return View(model);
            }

            //  Sign in the user using cookie authentication
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserEmail),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Redirect based on role
            return user.Role switch
            {
                "Admin" => RedirectToAction("Dashboard", "Admin"),
                "Donor" => RedirectToAction("Donor", "Donor"),
                "Volunteer" => RedirectToAction("Volunteer", "Volunteer"),
                _ => RedirectToAction("Index", "Home")
            };
        }
    }
    }

