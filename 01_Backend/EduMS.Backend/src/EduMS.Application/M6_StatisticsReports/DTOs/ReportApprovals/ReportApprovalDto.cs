using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.ReportApprovals;

public class ReportApprovalDto
{
    public long Id { get; set; }
    public long SystemReportId { get; set; }
    public long SchoolId { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    public long SubmittedByUserId { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public long? ReviewerId { get; set; }
    public DateTime? ReviewDate { get; set; }
    public string? Comments { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public long? ApprovedByUserId { get; set; }
    public string? DigitalSignatureHash { get; set; }
    public string? CertificateNumber { get; set; }
    public string? CertificatePath { get; set; }
    public bool IsFinal { get; set; }
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
