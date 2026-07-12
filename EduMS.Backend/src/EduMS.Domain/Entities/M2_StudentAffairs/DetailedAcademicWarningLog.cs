using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class DetailedAcademicWarningLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public DateTime WarningDate { get; set; } = DateTime.UtcNow;
    public int WarningCategory { get; set; } // 1=LowGrade, 2=HighAbsence, 3=Conduct
    public long? SubjectId { get; set; }
    public int WarningLevel { get; set; } // 1=FirstNotice, 2=SecondNotice, 3=FinalProbation
    public string TriggerDescription { get; set; } = string.Empty;
    public DateTime? GuardianAcknowledgedDate { get; set; }
    public long? IssuedByEmployeeId { get; set; }
    public string? RemedialPlanDescription { get; set; }
    public DateTime? TargetResolutionDate { get; set; }
    public int Status { get; set; } = 1; // 1=Active, 2=Resolved, 3=Escalated
    public bool IsEscalatedToDirector { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Subject? Subject { get; set; }
    public virtual Employee? IssuedByEmployee { get; set; }
}
