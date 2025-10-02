namespace GiftOfTheGiversHub.Data
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }// primary key
        public string VolunteerName { get; set; }
        public string VolunteerEmail { get; set; }
        public string VolunteerPhone { get; set; }
        public string Skill { get; set; }
        public string Availability { get; set; }

        public ICollection<Assignment> Assignments { get; set; } // Projects assigned to volunteer
    }
}
