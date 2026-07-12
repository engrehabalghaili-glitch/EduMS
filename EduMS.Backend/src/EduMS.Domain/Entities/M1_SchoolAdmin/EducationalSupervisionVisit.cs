using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class EducationalSupervisionVisit : BaseAuditableEntity
{
    public long DirectorateId { get; set; }
    public long SchoolId { get; set; }
    public string SupervisorName { get; set; } = string.Empty;
    public DateTime VisitDate { get; set; }
    public string VisitPurpose { get; set; } = string.Empty;
    public decimal? EvaluationScore { get; set; }
    public string? Recommendations { get; set; }
    public int Status { get; set; } // 1=Scheduled, 2=Completed, 3=FollowUpRequired
    public long? SupervisorEmployeeId { get; set; }
    public long? TargetDepartmentId { get; set; }
    public DateTime? FollowUpRequiredDate { get; set; }
    public string? ActionItemsDetail { get; set; }

    // Navigation Properties
    public virtual Directorate? Directorate { get; set; }
    public virtual School? School { get; set; }
}
