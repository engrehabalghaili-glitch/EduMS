using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// فئة الأصل - Asset category hierarchy extracted from ZIP ERD AssetCategory table (lines 6652-6677).
/// </summary>
public class AssetCategory : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public long? ParentCategoryId { get; set; }  // Self-referencing hierarchy
    public string CategoryCode { get; set; } = string.Empty;
    public string CategoryNameAr { get; set; } = string.Empty;
    public string? CategoryNameEn { get; set; }
    public int CategoryLevel { get; set; } = 1;
    public string? FullHierarchyPath { get; set; }
    public string? DescriptionAr { get; set; }
    public decimal DefaultDepreciationRate { get; set; }
    public int DefaultDepreciationMethod { get; set; } // 1=StraightLine, 2=DecliningBalance, 3=UnitsOfProduction
    public int DefaultUsefulLifeYears { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsSystemCategory { get; set; }
    public int SortOrder { get; set; }
    public string? Notes { get; set; }

    public virtual AssetCategory? ParentCategory { get; set; }
}

/// <summary>
/// حالة الأصل - Asset status lookup extracted from ZIP ERD AssetStatus table (lines 6707-6729).
/// </summary>
public class AssetStatusRecord : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public string StatusCode { get; set; } = string.Empty; // ACTIVE, MAINT, RETIRED
    public string StatusNameAr { get; set; } = string.Empty;
    public string? StatusNameEn { get; set; }
    public int StatusType { get; set; } // 1=Operational, 2=Maintenance, 3=OutOfService
    public bool IsOperational { get; set; }
    public bool IsAvailableForAssignment { get; set; }
    public bool RequiresApprovalToEnter { get; set; }
    public string? ColorCode { get; set; }  // Hex color for UI badges
    public bool IsActive { get; set; } = true;
    public bool IsSystemStatus { get; set; }
    public int SortOrder { get; set; }
    public string? DescriptionAr { get; set; }
}

/// <summary>
/// الموقع المكاني للأصل - Asset physical location extracted from ZIP ERD AssetLocation table (lines 6679-6705).
/// </summary>
public class AssetLocationRecord : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? ParentLocationId { get; set; }  // Self-referencing hierarchy
    public string LocationCode { get; set; } = string.Empty;  // B1-F2-R205
    public string LocationNameAr { get; set; } = string.Empty;
    public string? LocationNameEn { get; set; }
    public int LocationType { get; set; } // 1=Building, 2=Floor, 3=Wing, 4=Room, 5=Office, 6=Lab, 7=Warehouse, 8=Locker
    public string? BuildingName { get; set; }
    public int? FloorNumber { get; set; }
    public string? RoomNumber { get; set; }
    public bool IsActive { get; set; } = true;
    public long? ResponsiblePersonId { get; set; }  // FK Employee
    public string? MapReference { get; set; }
    public string? QrCode { get; set; }
    public string? Notes { get; set; }

    public virtual AssetLocationRecord? ParentLocation { get; set; }
}
