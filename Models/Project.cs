namespace GiftOfTheGiversHub.Models
{
    public class Project
    {
        public int ProjectId { get; set; } 
        
        public string ProjectName { get; set; }

        public string Region { get; set; }

        public string Tpye { get; set; }

        public string Status {  get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
