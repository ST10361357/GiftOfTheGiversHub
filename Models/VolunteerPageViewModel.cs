namespace GiftOfTheGiversHub.Models
{
    public class VolunteerPageViewModel
    {
        public VolunteerModel NewVolunteer { get; set; } = new VolunteerModel();
        public List<VolunteerModel> VolunteerList { get; set; } = new List<VolunteerModel>();
    }

}
