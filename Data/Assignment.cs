namespace GiftOfTheGiversHub.Data
{
    public class Assignment
    {
        public int AssignmentId { get; set; }//primary key
        public int DonorID { get; set; }//FK from Donor class
        public int VolunteerID { get; set; }// FK from Volunteer class
        public int ProjectID { get; set; }//Fk from Project class
        public string AssignmentRole { get; set; }//role in project
        public DateTime AssignedDate { get; set; }

        public Donor Donor { get; set; } // refer Donor class property
        public Volunteer Volunteer { get; set; } // refer Volunteer class property
        public Project Project { get; set; } // refer Project class property
    }

}

