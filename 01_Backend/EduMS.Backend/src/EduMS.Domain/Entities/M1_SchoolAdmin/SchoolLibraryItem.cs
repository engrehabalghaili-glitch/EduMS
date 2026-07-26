using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolLibraryItem : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ItemCode { get; set; } = string.Empty;
    public string TitleAr { get; set; } = string.Empty;
    public string? TitleEn { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public string? PublisherName { get; set; }
    public string? IsbnNumber { get; set; }
    public int Category { get; set; } // 1=AcademicReference, 2=Literature, 3=Science, 4=Periodicals, 5=DigitalMedia
    public int ItemStatus { get; set; } = 1; // 1=Available, 2=Borrowed, 3=UnderMaintenance, 4=LostOrDamaged
    public int TotalCopiesCount { get; set; } = 1;
    public int AvailableCopiesCount { get; set; } = 1;
    public string? ShelfLocationCode { get; set; }
    public decimal UnitPurchaseCost { get; set; }
    public DateTime? AcquisitionDate { get; set; }

    // Navigation Property
    public virtual School? School { get; set; }
}
