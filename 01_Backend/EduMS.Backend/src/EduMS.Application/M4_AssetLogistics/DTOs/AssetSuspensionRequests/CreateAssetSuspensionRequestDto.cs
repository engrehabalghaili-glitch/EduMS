using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetSuspensionRequests;

public class CreateAssetSuspensionRequestDto
{
    public long SchoolId { get; set; }
    public long RequestNumber { get; set; }
    public long AssetId { get; set; }
    public long RequestedByUserId { get; set; }
    public DateTime RequestDate { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string? ReasonDetails { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? ExpectedEndDate { get; set; }
    public string? AttachmentsJson { get; set; }
    public string ApprovalStatus { get; set; } = string.Empty;
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? ApprovalNotes { get; set; }
    public string? RejectionReason { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime? RevokeDate { get; set; }
    public string? RevokeReason { get; set; }
    public long? RevokedByUserId { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
}
