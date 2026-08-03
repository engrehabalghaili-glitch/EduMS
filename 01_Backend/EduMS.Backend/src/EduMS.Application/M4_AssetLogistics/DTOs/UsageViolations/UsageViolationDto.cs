using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.UsageViolations;

public class UsageViolationDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long AssetId { get; set; }
    public string ViolationType { get; set; } = string.Empty;
    public DateTime ViolationDate { get; set; }
    public long ReportedByUserId { get; set; }
    public DateTime ReportedDate { get; set; }
    public long ViolatingUserId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? EvidenceJson { get; set; }
    public string? PenaltyAction { get; set; }
    public decimal PenaltyAmount { get; set; }
    public string? PenaltyAmountCurrency { get; set; }
    public bool DeductionFromSalary { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime? ClosedAt { get; set; }
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
