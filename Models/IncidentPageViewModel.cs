namespace GiftOfTheGiversHub.Models
{
    public class IncidentPageViewModel
    {
        public IncidentModel NewIncident { get; set; } = new IncidentModel();
        public List<IncidentModel> IncidentList { get; set; } = new List<IncidentModel>();
    }

}
