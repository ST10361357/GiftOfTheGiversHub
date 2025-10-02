namespace GiftOfTheGiversHub.Data
{
    public class Donation
    {
        public int DonationId { get; set; }//primary key
        public double Amount { get; set; } = 0;
        public DateTime Date { get; set; }
        public string PayMethod { get; set; }//card & details
        public int DonorID { get; set; }// foreign key
    }
}
