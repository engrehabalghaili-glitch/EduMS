using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// طلبات تعليق الأصل - Asset suspension requests extracted from ZIP ERD AssetSuspensionRequests table (lines 7115-7144).
/// Standalone entity for managing temporary or permanent suspension of assets for security, technical, or investigative reasons.
/// </summary>
public class AssetSuspensionRequest : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long RequestNumber { get; set; }
    public long AssetId { get; set; }
    public long RequestedByUserId { get; set; }
    public DateTime RequestDate { get; set; }
    public string Reason { get; set; } = string.Empty; // e.g. Security, Technical, Administrative, UnderInvestigation, TotalDamage
    public string? ReasonDetails { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? ExpectedEndDate { get; set; }
    public string? AttachmentsJson { get; set; }
    public string ApprovalStatus { get; set; } = string.Empty; // UnderReview, Approved, Rejected, Cancelled
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? ApprovalNotes { get; set; }
    public string? RejectionReason { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime? RevokeDate { get; set; }
    public string? RevokeReason { get; set; }
    public long? RevokedByUserId { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public string Status { get; set; } = string.Empty; // Active, Expired, Cancelled
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual SchoolAsset? Asset { get; set; }
}
