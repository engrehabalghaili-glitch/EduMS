using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.DepreciationTransactions;

public class DepreciationTransactionDto
{
    public long Id { get; set; }
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
