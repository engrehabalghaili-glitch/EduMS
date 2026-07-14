using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceSpareParts;

public class UpdateMaintenanceSparePartDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PartCode { get; set; } = string.Empty;
    public string PartNameAr { get; set; } = string.Empty;
    public string? PartNameEn { get; set; }
    public string? PartCategory { get; set; }
    public string? Manufacturer { get; set; }
    public string? CompatibleAssetsJson { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public int CurrentStockQuantity { get; set; }
    public int MinStockLevel { get; set; }
    public int MaxStockLevel { get; set; }
    public int ReorderQuantity { get; set; }
    public decimal UnitCost { get; set; }
    public string? SupplierName { get; set; }
    public string? LocationInWarehouse { get; set; }
    public bool IsActive { get; set; } = true;
    public int StockStatus { get; set; } = 1;
    public DateTime? LastRestockDate { get; set; }
    public decimal TotalConsumed { get; set; }
    public string? Notes { get; set; }
}
