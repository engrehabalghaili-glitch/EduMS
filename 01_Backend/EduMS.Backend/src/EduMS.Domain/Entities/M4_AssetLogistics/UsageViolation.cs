using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// مخالفات الاستخدام - Usage violations extracted from ZIP ERD UsageViolations table (lines 7168-7193).
/// Standalone entity tracking asset misuse, policy violations, damages, and financial penalties.
/// </summary>
public class UsageViolation : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long AssetId { get; set; }
    public string ViolationType { get; set; } = string.Empty; // e.g. Misuse, UnauthorizedAccess, Negligence, UnauthorizedTransfer
    public DateTime ViolationDate { get; set; }
    public long ReportedByUserId { get; set; }
    public DateTime ReportedDate { get; set; }
    public long ViolatingUserId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? EvidenceJson { get; set; }
    public string? PenaltyAction { get; set; } // e.g. Warning, AssetSuspension, FinancialDeduction, Investigation
    public decimal PenaltyAmount { get; set; }
    public string? PenaltyAmountCurrency { get; set; }
    public bool DeductionFromSalary { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string Status { get; set; } = string.Empty; // Logged, UnderInvestigation, ActionTaken, Closed
    public DateTime? ClosedAt { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual SchoolAsset? Asset { get; set; }
}
