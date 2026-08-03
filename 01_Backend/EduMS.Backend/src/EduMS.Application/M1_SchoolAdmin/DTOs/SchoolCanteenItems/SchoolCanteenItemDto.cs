using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;

public class SchoolCanteenItemDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long? FacilityId { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string ItemNameAr { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public int NutritionalCategory { get; set; }
    public bool IsApprovedByHealthOfficer { get; set; }
    public string? ItemNameEn { get; set; }
    public decimal CostPrice { get; set; }
    public int ReorderThresholdQuantity { get; set; }
    public string? BarcodeNumber { get; set; }
    public int DailySalesLimitPerStudent { get; set; }
    public bool IsAvailable { get; set; }

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
