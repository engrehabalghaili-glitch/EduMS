using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentPsychologicalCounselingLogs;

public class StudentPsychologicalCounselingLogDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long CounselorEmployeeId { get; set; }
    public DateTime SessionDate { get; set; }
    public int SessionCategory { get; set; }
    public string? SessionNotes { get; set; }
    public string? RecommendedIntervention { get; set; }
    public bool IsConfidential { get; set; }
    public DateTime? FollowUpDate { get; set; }
    public int ReferralSource { get; set; }
    public int RiskAssessmentLevel { get; set; }
    public bool IsParentInvolved { get; set; }
    public int CaseStatus { get; set; }

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
