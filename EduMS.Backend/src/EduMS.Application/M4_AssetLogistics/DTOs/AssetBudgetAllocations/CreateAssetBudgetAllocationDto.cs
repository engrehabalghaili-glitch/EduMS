using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetBudgetAllocations;

public class CreateAssetBudgetAllocationDto
{
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
}
