using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetCategories;

public class AssetCategoryDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public long? ParentCategoryId { get; set; }
    public string CategoryCode { get; set; } = string.Empty;
    public string CategoryNameAr { get; set; } = string.Empty;
    public string? CategoryNameEn { get; set; }
    public int CategoryLevel { get; set; } = 1;
    public string? FullHierarchyPath { get; set; }
    public string? DescriptionAr { get; set; }
    public decimal DefaultDepreciationRate { get; set; }
    public int DefaultDepreciationMethod { get; set; }
    public int DefaultUsefulLifeYears { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsSystemCategory { get; set; }
    public int SortOrder { get; set; }
    public string? Notes { get; set; }
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
