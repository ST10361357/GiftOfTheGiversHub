using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversHub.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string UserEmail { get; set; } // Login email

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
