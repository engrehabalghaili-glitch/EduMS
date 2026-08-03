using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetAuditFinalApprovals;

public class AssetAuditFinalApprovalDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long? InventoryPlanId { get; set; }
    public long? ComplianceAuditId { get; set; }
    public int ApprovalType { get; set; }
    public DateTime ApprovalDate { get; set; }
    public long ApprovedByUserId { get; set; }
    public string? ApprovalDocumentUrl { get; set; }
    public string? SummaryOfChanges { get; set; }
    public bool SystemStatusUpdated { get; set; }
    public DateTime? StatusUpdateDate { get; set; }
    public long? StatusUpdatedByUserId { get; set; }
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
