using GiftOfTheGiversHub.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGiversHub.Controllers
{
    public class AccountController
    {

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
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

    }
}
