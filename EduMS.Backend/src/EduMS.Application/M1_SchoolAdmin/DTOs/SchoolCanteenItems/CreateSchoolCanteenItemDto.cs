using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;

public class CreateSchoolCanteenItemDto
{
    public long SchoolId { get; set; }
    public long? FacilityId { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string ItemNameAr { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public int NutritionalCategory { get; set; }
    public bool IsApprovedByHealthOfficer { get; set; } = true;
    public string? ItemNameEn { get; set; }
    public decimal CostPrice { get; set; }
    public int ReorderThresholdQuantity { get; set; } = 10;
    public string? BarcodeNumber { get; set; }
    public int DailySalesLimitPerStudent { get; set; } = 2;
    public bool IsAvailable { get; set; } = true;
}
