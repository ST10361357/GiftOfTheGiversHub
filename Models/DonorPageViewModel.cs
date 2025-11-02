namespace GiftOfTheGiversHub.Models
{
    public class DonorPageViewModel
    {
        public DonatorModel NewDonator { get; set; } = new DonatorModel();
        public List<DonatorModel> DonatorList { get; set; } = new List<DonatorModel>();
    }

}
