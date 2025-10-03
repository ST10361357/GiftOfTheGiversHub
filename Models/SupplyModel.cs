using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace GiftOfTheGiversHub.Data
{
    public class SupplyModel
    {
        public int SupplyId { get; set; }  

        public int ProjectId { get; set; } 
        public int DonationId { get; set; } 

        public string ItemName { get; set; }
        public int Quantity { get; set; } 
        public string SupplyStatus { get; set; } // e.g., Pending, Delivered, Delayed
        public DateTime DeliveryDate { get; set; } // Date of delivery

        // Navigation properties
        public Project Project { get; set; }
        public Donation Donation { get; set; }
    }
}

