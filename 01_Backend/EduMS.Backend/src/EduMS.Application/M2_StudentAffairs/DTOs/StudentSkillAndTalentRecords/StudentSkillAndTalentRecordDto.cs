using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentSkillAndTalentRecords;

public class StudentSkillAndTalentRecordDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public int TalentCategory { get; set; }
    public string TalentTitleAr { get; set; } = string.Empty;
    public int ProficiencyLevel { get; set; }
    public DateTime DiscoveredDate { get; set; }
    public long? MentorEmployeeId { get; set; }
    public string? TalentTitleEn { get; set; }
    public string? DevelopmentPlanDescription { get; set; }
    public string? PortfolioAttachmentUrl { get; set; }
    public bool IsEnrolledInGiftedProgram { get; set; }

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
