using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetTechnicalSpecifications;

public class AssetTechnicalSpecificationDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public string SpecCode { get; set; } = string.Empty;
    public string SpecNameAr { get; set; } = string.Empty;
    public string? SpecNameEn { get; set; }
    public long? AssetCategoryId { get; set; }
    public string? AssetTypeDescription { get; set; }
    public string? TechnicalDetailsJson { get; set; }
    public string? RequiredCertifications { get; set; }
    public string? AcceptanceCriteria { get; set; }
    public string? QualityStandards { get; set; }
    public string? WarrantyRequirements { get; set; }
    public string? SafetyRequirements { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string SpecVersion { get; set; } = "V1.0";
    public string? AttachmentsJson { get; set; }
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
