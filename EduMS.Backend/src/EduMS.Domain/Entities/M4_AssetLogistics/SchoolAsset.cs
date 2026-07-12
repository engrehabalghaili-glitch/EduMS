using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الأصل المدرسي - Core asset record extracted from ZIP ERD Asset table (lines 6610-6650).
/// Replaces the existing AssetAllocation.cs/InventoryItem.cs thin models with the full 40-field ERD spec.
/// </summary>
public class SchoolAsset : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string AssetUniqueCode { get; set; } = string.Empty;  // AST-2024-00001
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
    public int Condition { get; set; } // 1=New, 2=Good, 3=NeedsMaintenance, 4=Damaged, 5=Decommissioned
    public int AcquisitionType { get; set; } // 1=Purchase, 2=Donation, 3=InternalTransfer, 4=Rental
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
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual AssetCategory? Category { get; set; }
    public virtual AssetLocationRecord? Location { get; set; }
    public virtual AssetWarrantyContract? WarrantyContract { get; set; }
}
