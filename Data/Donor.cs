namespace GiftOfTheGiversHub.Data
{
    //donor details
    public class Donor
    {
        public int DonorId { get; set; }//primary key
        public string DonorName { get; set; }
        public string DonorEmail { get; set; }
        public string DonorPhone { get; set; }
        public string Organisation { get; set; }


        public ICollection<Donation> Donations { get; set; } // Donations made by donor
        public ICollection<Assignment> Assignments { get; set; } // Assignments linked donor to projects



    }
}
