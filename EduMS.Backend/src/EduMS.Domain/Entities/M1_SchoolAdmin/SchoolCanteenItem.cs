using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolCanteenItem : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? FacilityId { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string ItemNameAr { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public int NutritionalCategory { get; set; } // 1=HealthySnack, 2=Beverage, 3=Meal
    public bool IsApprovedByHealthOfficer { get; set; } = true;
    public string? ItemNameEn { get; set; }
    public decimal CostPrice { get; set; }
    public int ReorderThresholdQuantity { get; set; } = 10;
    public string? BarcodeNumber { get; set; }
    public int DailySalesLimitPerStudent { get; set; } = 2;
    public bool IsAvailable { get; set; } = true;

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual SchoolFacility? Facility { get; set; }
}
