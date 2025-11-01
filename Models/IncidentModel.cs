using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversHub.Models
{
   
    public class IncidentModel
    {
        [Key]
        public int IncidentId { get; set; }
        public string ReporterName { get; set; }
        public string ReporterEmail { get; set; }
        public string IncidentType { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string UrgencyLevel { get; set; }
        public DateTime DateReported { get; set; }
        public string AssignedVolunteerEmail { get; set; }
        public string Status { get; set; } = "Pending";
    }

}
