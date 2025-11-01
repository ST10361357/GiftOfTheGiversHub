using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversHub.Models
{
    public class DonatorModel
    {
        [Key]
        public int DonatorId { get; set; }

        [Required]
        public string DonatorName { get; set; }

        [Required, EmailAddress]
        public string DonatorEmail { get; set; }

        public string DonationType { get; set; } // e.g., Food, Medical, Funds

        public string Notes { get; set; }
    }

}
