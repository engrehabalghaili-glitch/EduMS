using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.InventoryReconciliations;

public class InventoryReconciliationDto
{
    public long Id { get; set; }
    public long InventoryPlanId { get; set; }
    public long SchoolId { get; set; }
    public long AssetId { get; set; }
    public int DiscrepancyType { get; set; }
    public long? SystemLocationId { get; set; }
    public string? ActualLocationText { get; set; }
    public int SystemCondition { get; set; }
    public int ActualCondition { get; set; }
    public string? ReasonForDiscrepancy { get; set; }
    public string? InvestigationNotes { get; set; }
    public string? CorrectiveAction { get; set; }
    public bool IsResolved { get; set; }
    public DateTime? ResolutionDate { get; set; }
    public long? ResolvedByUserId { get; set; }
    public string? ResolutionNotes { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int ReconciliationStatus { get; set; } = 1;
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
