using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.InventoryPlans;

public class CreateInventoryPlanDto
{
    public long SchoolId { get; set; }
    public string PlanNumber { get; set; } = string.Empty;
    public string PlanNameAr { get; set; } = string.Empty;
    public int InventoryType { get; set; }
    public int ScopeType { get; set; }
    public long? ScopeValueId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? TargetEndDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public long? TeamLeaderEmployeeId { get; set; }
    public string? AssignedTeamMembersJson { get; set; }
    public string? Instructions { get; set; }
    public int PlanStatus { get; set; } = 1;
    public decimal CompletionPercentage { get; set; }
    public string? Notes { get; set; }
}
