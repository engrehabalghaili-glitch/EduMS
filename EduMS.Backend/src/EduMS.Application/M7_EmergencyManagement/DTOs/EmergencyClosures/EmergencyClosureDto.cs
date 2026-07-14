using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyClosures;

public class EmergencyClosureDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ClosureNumber { get; set; } = string.Empty;
    public string ClosureReason { get; set; } = string.Empty;
    public string? DecisionAuthority { get; set; }
    public string? AuthorityDecisionNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public int TotalClosureDays { get; set; }
    public int SchoolDaysAffected { get; set; }
    public bool AlternativeEducationActivated { get; set; }
    public string? AlternativeEducationType { get; set; }
    public string? AltEducationPlatform { get; set; }
    public string? AltEducationDetails { get; set; }
    public bool WasCompensated { get; set; }
    public long? CompensationRemediationPlanId { get; set; }
    public bool ParentNotificationSent { get; set; }
    public DateTime? ParentNotificationDate { get; set; }
    public string? ParentNotificationMethod { get; set; }
    public int ClosureStatus { get; set; } = 1;
    public string? Notes { get; set; }
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
