namespace GiftOfTheGiversHub.Models
{
    public class AdminDashboardViewModel
    {
        public List<UserModel> Admins { get; set; }
        public List<UserModel> Staff { get; set; }

        public List<IncidentModel> Incidents { get; set; }
        public List<UserModel> Volunteers { get; set; }
    }
}
