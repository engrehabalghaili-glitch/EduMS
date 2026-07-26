using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialses;

public class AssetFinancialsDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal ShippingCosts { get; set; }
    public decimal CustomsFees { get; set; }
    public decimal InstallationCosts { get; set; }
    public decimal OtherCosts { get; set; }
    public decimal TotalInitialCost { get; set; }
    public string? Currency { get; set; }
    public decimal ExchangeRateToSar { get; set; } = 1;
    public decimal SalvageValue { get; set; }
    public DateTime? ResidualValueLastUpdate { get; set; }
    public string? FiscalYear { get; set; }
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
