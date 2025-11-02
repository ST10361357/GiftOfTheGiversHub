using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversHub.Models
{
   
    public class IncidentModel
    {
        [Key]
        public int IncidentId { get; set; }
        [Required]
        public string ReporterName { get; set; }
        [Required]
        [EmailAddress]
        public string ReporterEmail { get; set; }
        [Required]
        public string IncidentType { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UrgencyLevel { get; set; }
        public DateTime DateReported { get; set; } = DateTime.Now;
        public string? AssignedVolunteerEmail { get; set; }

        public string? AssignedDonatorEmail { get; set; }
        public string Status { get; set; } = "Pending";
    }

}
