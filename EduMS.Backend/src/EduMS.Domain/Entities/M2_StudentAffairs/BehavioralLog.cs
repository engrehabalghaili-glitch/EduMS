using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class BehavioralLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public DateTime IncidentDate { get; set; }
    public int BehaviorCategory { get; set; } // 1=Positive, 2=MinorInfraction, 3=MajorInfraction
    public string IncidentTitleAr { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ActionTaken { get; set; }
    public long? RecordedByEmployeeId { get; set; }
    public int Status { get; set; } // 1=UnderReview, 2=Resolved
    public string? IncidentTitleEn { get; set; }
    public int DemeritOrMeritPoints { get; set; }
    public string? IncidentLocation { get; set; }
    public int ParentNotificationStatus { get; set; } = 1; // 1=NotSent, 2=Sent, 3=Acknowledged
    public string? InvestigationNotes { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Employee? RecordedByEmployee { get; set; }
}
