namespace GiftOfTheGiversHub.Data
{
    public class Assignment
    {
        public int AssignmentId { get; set; }//primary key
        public int DonorID { get; set; }//FK from Donor class
        public int VolunteerID { get; set; }// FK from Volunteer class
        public int ProjectID { get; set; }//Fk from Project class
        public string AssignRole { get; set; }//role in project
        public DateTime AssignedDate { get; set; }

    }
}
