using System.ComponentModel.DataAnnotations;


namespace GiftOfTheGiversHub.Models
{
    public class AppUserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

