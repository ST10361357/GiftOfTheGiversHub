namespace GiftOfTheGiversHub.Data
{
    //donor details
    public class Donor
    {
        public int DonorID { get; set; }//primary key
        public string DonorName { get; set; }
        public string DonorEmail { get; set; }
        public string DonorPhone { get; set; }
        public string Organisation { get; set; }


    }
}
