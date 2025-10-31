namespace GiftOfTheGiversHub.Data
{
    public class RoleChangeLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OldRole { get; set; }
        public string NewRole { get; set; }
        public string ChangedBy { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
