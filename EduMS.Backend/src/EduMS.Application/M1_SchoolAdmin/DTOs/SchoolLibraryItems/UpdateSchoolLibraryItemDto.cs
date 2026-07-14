using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLibraryItems;

public class UpdateSchoolLibraryItemDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string TitleAr { get; set; } = string.Empty;
    public string? TitleEn { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string? PublisherName { get; set; }
    public string? IsbnNumber { get; set; }
    public int Category { get; set; }
    public int ItemStatus { get; set; }
    public int TotalCopiesCount { get; set; }
    public int AvailableCopiesCount { get; set; }
    public string? ShelfLocationCode { get; set; }
    public decimal UnitPurchaseCost { get; set; }
    public DateTime? AcquisitionDate { get; set; }
}
