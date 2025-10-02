namespace GiftOfTheGiversHub.Data
{
    public class Supply
    {
        public int SupplyId { get; set; }  //primary key
        public int ProjectID { get; set; }
        public int DonationID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string SupplyStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
