using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExtracurricularAchievements;

public class StudentExtracurricularAchievementDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string CompetitionTitleAr { get; set; } = string.Empty;
    public string? CompetitionTitleEn { get; set; }
    public int CompetitionLevel { get; set; }
    public string OrganizingInstitutionName { get; set; } = string.Empty;
    public DateTime AchievementDate { get; set; }
    public int RankOrMedalAchieved { get; set; }
    public string? AwardDescription { get; set; }
    public decimal MonetaryPrizeAmount { get; set; }
    public long? SupervisingCoachEmployeeId { get; set; }
    public string? CertificateOrMedalPhotoUrl { get; set; }

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
