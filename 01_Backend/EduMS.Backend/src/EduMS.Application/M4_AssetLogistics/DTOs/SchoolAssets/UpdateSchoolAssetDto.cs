using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.SchoolAssets;

public class UpdateSchoolAssetDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string AssetUniqueCode { get; set; } = string.Empty;
    public string AssetNameAr { get; set; } = string.Empty;
    public string? AssetNameEn { get; set; }
    public string? AssetTag { get; set; }
    public string? SerialNumber { get; set; }
    public string? ModelNumber { get; set; }
    public string? Manufacturer { get; set; }
    public string? Brand { get; set; }
    public long? AssetCategoryId { get; set; }
    public long? AssetStatusId { get; set; }
    public long? AssetLocationId { get; set; }
    public int Condition { get; set; }
    public int AcquisitionType { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public decimal AcquisitionCost { get; set; }
    public string? SupplierName { get; set; }
    public string? PurchaseOrderReference { get; set; }
    public long? WarrantyContractId { get; set; }
    public bool IsInsured { get; set; }
    public string? InsurancePolicyNumber { get; set; }
    public DateTime? InsuranceExpiryDate { get; set; }
    public int UsefulLifeYears { get; set; }
    public decimal SalvageValue { get; set; }
    public decimal CurrentBookValue { get; set; }
    public string? Barcode { get; set; }
    public string? QrCode { get; set; }
    public string? RfidTag { get; set; }
    public bool HasPhysicalTag { get; set; }
    public DateTime? PhysicalTagDate { get; set; }
    public string? Currency { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
