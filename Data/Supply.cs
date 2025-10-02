namespace GiftOfTheGiversHub.Data
{
    public class Supply
    {
        public int SupplyId { get; set; }  //primary key
        public int ProjectId { get; set; }
        public int DonationId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string SupplyStatus { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Project Project { get; set; } // refer to the Project class anf fields 
        public Donation Donation { get; set; } // refer to the Donation class anf fields
    }
}

