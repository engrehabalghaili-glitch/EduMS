using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetExpenses;

public class UpdateAssetExpenseDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int ExpenseType { get; set; }
    public DateTime ExpenseDate { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }
    public string? Description { get; set; }
    public long? RelatedMaintenanceExecutionId { get; set; }
    public bool IsCapitalized { get; set; }
    public DateTime? CapitalizationDate { get; set; }
    public bool AccountedInFinancials { get; set; }
    public bool AccountedInDepreciation { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }
}
