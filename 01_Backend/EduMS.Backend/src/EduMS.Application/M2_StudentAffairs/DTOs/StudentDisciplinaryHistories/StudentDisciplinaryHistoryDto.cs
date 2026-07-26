using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentDisciplinaryHistories;

public class StudentDisciplinaryHistoryDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long? BehavioralLogId { get; set; }
    public string DisciplinaryActionCode { get; set; } = string.Empty;
    public string ActionTitleAr { get; set; } = string.Empty;
    public DateTime ExecutionDate { get; set; }
    public long? ExecutedByEmployeeId { get; set; }
    public int PenaltyDurationDays { get; set; }
    public DateTime? GuardianNotifiedDate { get; set; }
    public int AppealStatus { get; set; }
    public string? ActionTitleEn { get; set; }
    public string? AppealNotes { get; set; }
    public string? ReinstatementCondition { get; set; }
    public int Status { get; set; }

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
