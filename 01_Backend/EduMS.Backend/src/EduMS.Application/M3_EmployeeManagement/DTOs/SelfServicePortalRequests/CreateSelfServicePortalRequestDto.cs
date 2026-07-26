using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.SelfServicePortalRequests;

public class CreateSelfServicePortalRequestDto
{
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
}
