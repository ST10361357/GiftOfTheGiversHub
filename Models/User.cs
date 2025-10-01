namespace GiftOfTheGiversHub.Models
{
    public class User
    {
        public int UserId { get; set; }// primary key
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Role { get; set; }// Admin, Donor, Volunteer
        public string PasswordHash { get; set; }
    }
}
