using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetInspectionLogs;

public class AssetInspectionLogDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public string RelatedTransactionType { get; set; } = string.Empty;
    public long? RelatedTransactionId { get; set; }
    public int InspectionType { get; set; }
    public DateTime InspectionDate { get; set; }
    public long InspectorUserId { get; set; }
    public int PhysicalCondition { get; set; }
    public string? DamageDetails { get; set; }
    public string? DamagePhotosJson { get; set; }
    public int FunctionalStatus { get; set; }
    public string? MissingPartsJson { get; set; }
    public int InspectionResult { get; set; }
    public string? RecommendedAction { get; set; }
    public decimal EstimatedRepairCost { get; set; }
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
