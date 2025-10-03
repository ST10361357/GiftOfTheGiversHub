using GiftOfTheGiversHub.Data;
using Microsoft.AspNetCore.Mvc;

public class Incident
{
    public int IncidentId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Severity { get; set; } // e.g., Low, Medium, High, Critical

    public DateTime ReportedDate { get; set; }

    public string ReportedBy { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; } // Navigation property
}

