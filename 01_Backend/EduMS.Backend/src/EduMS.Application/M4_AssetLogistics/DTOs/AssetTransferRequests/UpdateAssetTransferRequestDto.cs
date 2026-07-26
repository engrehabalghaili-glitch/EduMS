using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetTransferRequests;

public class UpdateAssetTransferRequestDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public int FromEntityType { get; set; }
    public long FromEntityId { get; set; }
    public int ToEntityType { get; set; }
    public long ToEntityId { get; set; }
    public int TransferType { get; set; }
    public string? RequestReason { get; set; }
    public long? RequestedByUserId { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public int ApprovalStatus { get; set; } = 1;
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? TransferExecutionDate { get; set; }
    public long? ExecutedByUserId { get; set; }
    public int RequestStatus { get; set; } = 1;
    public string? Notes { get; set; }
}
