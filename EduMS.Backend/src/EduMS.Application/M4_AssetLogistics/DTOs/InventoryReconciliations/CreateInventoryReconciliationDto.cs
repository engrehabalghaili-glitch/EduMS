using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.InventoryReconciliations;

public class CreateInventoryReconciliationDto
{
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
}
