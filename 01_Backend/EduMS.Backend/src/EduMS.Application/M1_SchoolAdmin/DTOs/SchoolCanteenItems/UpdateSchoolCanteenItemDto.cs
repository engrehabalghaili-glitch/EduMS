using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCanteenItems;

public class UpdateSchoolCanteenItemDto
{
    public long Id { get; set; }
    public long? FacilityId { get; set; }
    public string ItemCode { get; set; }
    public string ItemNameAr { get; set; }
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
}
