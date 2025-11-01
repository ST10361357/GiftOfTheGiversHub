using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversHub.Models
{
    public class VolunteerModel
    {
        [Key]
        public int VolunteerId { get; set; }

        [Required]
        public string VolunteerName { get; set; }

        [Required, EmailAddress]
        public string VolunteerEmail { get; set; }

        public string Skills { get; set; }

        public string Availability { get; set; } // e.g., Weekends, Full-time, etc.
    }
}