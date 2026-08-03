using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.AcademicWarningPolicies;

public class AcademicWarningPolicyDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PolicyCode { get; set; } = string.Empty;
    public string PolicyTitleAr { get; set; } = string.Empty;
    public int WarningCategory { get; set; }
    public decimal ThresholdValue { get; set; }
    public int ActionRequired { get; set; }
    public string? PolicyTitleEn { get; set; }
    public int ConsecutiveOccurrenceLimit { get; set; }
    public bool AutoTriggerNotification { get; set; }
    public long? EscalationPolicyId { get; set; }
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
