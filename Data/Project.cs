namespace GiftOfTheGiversHub.Data
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string Region { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Assignment> Assignments { get; set; } // Donors and volunteers linked to a project
        public ICollection<SupplyModel> Supplies { get; set; } // Supplies delivered to a project
        public ICollection<Alert> Alerts { get; set; } // Alerts related to a project
    }
}

