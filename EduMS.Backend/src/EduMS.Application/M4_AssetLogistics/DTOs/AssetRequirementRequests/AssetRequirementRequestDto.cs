using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetRequirementRequests;

public class AssetRequirementRequestDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public int RequestType { get; set; }
    public string AssetTypeDescription { get; set; } = string.Empty;
    public long? AssetCategoryId { get; set; }
    public int QuantityRequested { get; set; }
    public decimal EstimatedUnitCost { get; set; }
    public decimal EstimatedTotalCost { get; set; }
    public int Priority { get; set; }
    public string? UrgencyReason { get; set; }
    public long? RequestingDepartmentId { get; set; }
    public long? RequestedByEmployeeId { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public string? Justification { get; set; }
    public string? InitialSpecsText { get; set; }
    public DateTime? RequiredByDate { get; set; }
    public bool IsReplacement { get; set; }
    public long? AssetToReplaceId { get; set; }
    public string? ReplacementReason { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public string? RejectionReason { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public bool ConvertedToPurchaseOrder { get; set; }
    public long? PurchaseOrderId { get; set; }
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
