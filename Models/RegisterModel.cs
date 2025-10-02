using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversHub.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username field cannot be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email field cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string UserEmail { get; set; } 

        [Required(ErrorMessage = "Enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }
}
