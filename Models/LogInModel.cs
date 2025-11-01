using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversHub.Models
{
    public class LogInModel
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}