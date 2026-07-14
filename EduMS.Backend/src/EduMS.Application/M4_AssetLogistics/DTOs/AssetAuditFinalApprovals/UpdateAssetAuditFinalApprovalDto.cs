using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetAuditFinalApprovals;

public class UpdateAssetAuditFinalApprovalDto
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
}
