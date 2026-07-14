using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLibraryItems;

public class SchoolLibraryItemDto
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
