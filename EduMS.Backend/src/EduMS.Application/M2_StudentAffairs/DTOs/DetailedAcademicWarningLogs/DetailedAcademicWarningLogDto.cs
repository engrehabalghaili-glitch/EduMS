using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.DetailedAcademicWarningLogs;

public class DetailedAcademicWarningLogDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public DateTime WarningDate { get; set; }
    public int WarningCategory { get; set; }
    public long? SubjectId { get; set; }
    public int WarningLevel { get; set; }
    public string TriggerDescription { get; set; } = string.Empty;
    public DateTime? GuardianAcknowledgedDate { get; set; }
    public long? IssuedByEmployeeId { get; set; }
    public string? RemedialPlanDescription { get; set; }
    public DateTime? TargetResolutionDate { get; set; }
    public int Status { get; set; }
    public bool IsEscalatedToDirector { get; set; }

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
