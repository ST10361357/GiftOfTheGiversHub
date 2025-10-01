namespace GiftOfTheGiversHub.Models
{
    public class Beneficiary
    {
        public int BeneficiaryId { get; set; }// primary key
        public string BeneficiaryName { get; set; }
        public string Type {  get; set; }  // organisation or individual
        public string Location {  get; set; }   
        public int Capacity {  get; set; }  
    }
}
