namespace GiftOfTheGiversHub.Data
{
    public class Alert
    {
        public int AlertId { get; set; }//primary key
        public int ProjectId { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public string Channel { get; set; }// email

        public Project Project { get; set; } // refer  to the Project class property


    }
}
