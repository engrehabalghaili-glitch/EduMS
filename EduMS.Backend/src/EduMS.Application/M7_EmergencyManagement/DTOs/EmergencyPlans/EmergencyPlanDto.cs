using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyPlans;

public class EmergencyPlanDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public string PlanTitleAr { get; set; } = string.Empty;
    public string PlanTitleEn { get; set; } = string.Empty;
    public string EvacuationProcedureSummary { get; set; } = string.Empty;
    public DateTime NextScheduledDrillDate { get; set; }
    public bool IsActive { get; set; } = true;
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
