using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialses;

public class UpdateAssetFinancialsDto
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
}
