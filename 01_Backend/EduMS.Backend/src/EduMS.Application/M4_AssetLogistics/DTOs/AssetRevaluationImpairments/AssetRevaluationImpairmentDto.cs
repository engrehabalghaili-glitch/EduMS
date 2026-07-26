using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetRevaluationImpairments;

public class AssetRevaluationImpairmentDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int OperationType { get; set; }
    public DateTime EffectiveDate { get; set; }
    public decimal OldBookValue { get; set; }
    public decimal OldAccumulatedDepreciation { get; set; }
    public decimal OldNetBookValue { get; set; }
    public decimal NewValue { get; set; }
    public decimal NewNetBookValue { get; set; }
    public decimal DifferenceAmount { get; set; }
    public int DifferenceType { get; set; }
    public string? ValuationFirmName { get; set; }
    public string? ValuationReportNumber { get; set; }
    public DateTime? ValuationReportDate { get; set; }
    public string? Reason { get; set; }
    public string? AttachmentUrl { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int OperationStatus { get; set; } = 1;
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
