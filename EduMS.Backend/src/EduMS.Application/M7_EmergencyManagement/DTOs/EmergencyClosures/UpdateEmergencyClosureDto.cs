using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyClosures;

public class UpdateEmergencyClosureDto
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
}
