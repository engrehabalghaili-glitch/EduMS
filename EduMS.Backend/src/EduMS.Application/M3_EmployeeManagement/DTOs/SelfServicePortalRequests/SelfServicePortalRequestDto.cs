using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.SelfServicePortalRequests;

public class SelfServicePortalRequestDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public int RequestType { get; set; }
    public string RequestTitleAr { get; set; } = string.Empty;
    public string? RequestDetailsText { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    public int RequestStatus { get; set; } = 1;
    public long? ReviewedByUserId { get; set; }
    public DateTime? ReviewDate { get; set; }
    public string? RejectionReason { get; set; }
    public string? AttachmentUrl { get; set; }
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
