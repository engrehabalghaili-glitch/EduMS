using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetBudgetAllocations;

public class AssetBudgetAllocationDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public int BudgetType { get; set; }
    public long? AssetCategoryId { get; set; }
    public long? DepartmentId { get; set; }
    public decimal AllocatedAmount { get; set; }
    public decimal SpentAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string? BudgetLineCode { get; set; }
    public int AllocationStatus { get; set; } = 1;
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
