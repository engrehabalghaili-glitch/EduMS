using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentDisciplinaryHistory : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long? BehavioralLogId { get; set; }
    public string DisciplinaryActionCode { get; set; } = string.Empty;
    public string ActionTitleAr { get; set; } = string.Empty;
    public DateTime ExecutionDate { get; set; } = DateTime.UtcNow;
    public long? ExecutedByEmployeeId { get; set; }
    public int PenaltyDurationDays { get; set; }
    public DateTime? GuardianNotifiedDate { get; set; }
    public int AppealStatus { get; set; } // 1=None, 2=Submitted, 3=Accepted, 4=Rejected
    public string? ActionTitleEn { get; set; }
    public string? AppealNotes { get; set; }
    public string? ReinstatementCondition { get; set; }
    public int Status { get; set; } = 1; // 1=Active, 2=Completed, 3=Revoked

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual BehavioralLog? BehavioralLog { get; set; }
    public virtual Employee? ExecutedByEmployee { get; set; }
}
