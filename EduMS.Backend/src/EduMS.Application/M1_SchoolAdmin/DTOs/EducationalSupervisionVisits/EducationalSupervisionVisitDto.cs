using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.EducationalSupervisionVisits;

public class EducationalSupervisionVisitDto
{
    public long Id { get; set; }
    public long DirectorateId { get; set; }
    public long SchoolId { get; set; }
    public string SupervisorName { get; set; } = string.Empty;
    public DateTime VisitDate { get; set; }
    public string VisitPurpose { get; set; } = string.Empty;
    public decimal? EvaluationScore { get; set; }
    public string? Recommendations { get; set; }
    public int Status { get; set; }
    public long? SupervisorEmployeeId { get; set; }
    public long? TargetDepartmentId { get; set; }
    public DateTime? FollowUpRequiredDate { get; set; }
    public string? ActionItemsDetail { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
