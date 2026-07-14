using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentActivityParticipations;

public class StudentActivityParticipationDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public string ActivityNameAr { get; set; } = string.Empty;
    public int ActivityType { get; set; }
    public long? SupervisorEmployeeId { get; set; }
    public DateTime ParticipationDate { get; set; }
    public string? AchievementDetail { get; set; }
    public decimal ScoreBonus { get; set; }
    public string? ActivityNameEn { get; set; }
    public string? ParticipationRole { get; set; }
    public int TotalHoursLogged { get; set; }
    public string? AwardLevel { get; set; }

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
