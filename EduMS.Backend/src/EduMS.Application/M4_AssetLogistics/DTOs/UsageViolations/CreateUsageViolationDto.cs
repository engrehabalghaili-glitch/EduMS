using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.UsageViolations;

public class CreateUsageViolationDto
{
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
}
