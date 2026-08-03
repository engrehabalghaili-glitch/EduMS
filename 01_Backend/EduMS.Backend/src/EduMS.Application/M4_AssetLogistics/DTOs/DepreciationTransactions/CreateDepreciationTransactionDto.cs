using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.DepreciationTransactions;

public class CreateDepreciationTransactionDto
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public long? DepreciationPolicyId { get; set; }
    public string PeriodStart { get; set; } = string.Empty;
    public string PeriodEnd { get; set; } = string.Empty;
    public int PeriodType { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public int PeriodNumber { get; set; }
    public decimal DepreciationAmount { get; set; }
    public decimal AccumulatedDepreciationAfter { get; set; }
    public decimal NetBookValueAfter { get; set; }
    public bool IsPostedToLedger { get; set; }
    public string? LedgerEntryReference { get; set; }
    public DateTime? PostedToLedgerDate { get; set; }
    public long? CalculatedByUserId { get; set; }
    public DateTime? CalculationDate { get; set; }
    public string? Notes { get; set; }
}
