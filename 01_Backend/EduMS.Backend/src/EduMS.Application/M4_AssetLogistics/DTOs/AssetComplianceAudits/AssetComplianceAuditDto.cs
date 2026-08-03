using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetComplianceAudits;

public class AssetComplianceAuditDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string AuditNumber { get; set; } = string.Empty;
    public DateTime AuditDate { get; set; }
    public int AuditType { get; set; }
    public string? StandardType { get; set; }
    public long AuditedByUserId { get; set; }
    public string? AuditScope { get; set; }
    public decimal ComplianceScore { get; set; }
    public string? ViolationsFoundJson { get; set; }
    public string? CorrectiveActionsRequired { get; set; }
    public string? CorrectiveActionsDeadline { get; set; }
    public int CorrectiveActionsStatus { get; set; }
    public DateTime? FollowUpAuditDate { get; set; }
    public string? AuditReportUrl { get; set; }
    public int AuditStatus { get; set; } = 1;
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
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
