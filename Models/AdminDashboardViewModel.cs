namespace GiftOfTheGiversHub.Models
{
    public class AdminDashboardViewModel
    {
        public List<UserModel> Admins { get; set; } = new();
        public List<UserModel> Staff { get; set; } = new();

        public List<IncidentModel> Incidents { get; set; } = new();
        public List<UserModel> Volunteers { get; set; } = new();
        public List<DonatorModel> Donators { get; set; } = new();

        // New reporting data
        public List<StatusReportItem> StatusReport { get; set; } = new();
        public List<UrgencyReportItem> UrgencyReport { get; set; } = new();
    }

    public class StatusReportItem
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }

    public class UrgencyReportItem
    {
        public string UrgencyLevel { get; set; } 
        public int Count { get; set; }
    }
}

