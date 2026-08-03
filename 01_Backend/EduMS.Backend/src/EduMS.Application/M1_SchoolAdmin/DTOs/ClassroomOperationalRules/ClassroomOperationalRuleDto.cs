using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;

public class ClassroomOperationalRuleDto
{
    public long Id { get; set; }
    public long ClassroomId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string RuleTitleAr { get; set; } = string.Empty;
    public string RuleTitleEn { get; set; } = string.Empty;
    public decimal MaxAllowedAbsencePercentage { get; set; }
    public bool RequiresDailyAttendanceLog { get; set; }
    public int AllowLateArrivalMinutes { get; set; }
    public int MaxAllowedConsecutiveAbsenceDays { get; set; }
    public int PenaltyTypeForExceedingLimit { get; set; }
    public DateTime? EffectiveStartDate { get; set; }
    public bool IsActive { get; set; }

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
