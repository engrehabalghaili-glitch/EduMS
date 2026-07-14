using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLibraryItems;

public class CreateSchoolLibraryItemDto
{
    public long SchoolId { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string TitleAr { get; set; } = string.Empty;
    public string? TitleEn { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string? PublisherName { get; set; }
    public string? IsbnNumber { get; set; }
    public int Category { get; set; }
    public int ItemStatus { get; set; } = 1;
    public int TotalCopiesCount { get; set; } = 1;
    public int AvailableCopiesCount { get; set; } = 1;
    public string? ShelfLocationCode { get; set; }
    public decimal UnitPurchaseCost { get; set; }
    public DateTime? AcquisitionDate { get; set; }
}
