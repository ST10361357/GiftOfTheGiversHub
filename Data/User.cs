namespace GiftOfTheGiversHub.Data
{
    public class User
    {
        public int UserId { get; set; }// primary key
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Role { get; set; }// Admin, Donor, Volunteer
        public string Password { get; set; }//hashed password
    }
}
