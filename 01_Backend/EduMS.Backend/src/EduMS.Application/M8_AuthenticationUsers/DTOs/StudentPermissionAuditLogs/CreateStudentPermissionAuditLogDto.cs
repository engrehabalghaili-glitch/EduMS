using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.StudentPermissionAuditLogs;

public class CreateStudentPermissionAuditLogDto
{
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long UserId { get; set; }
    public string? UserRole { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
    public long? EntityId { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public string? AccessContextJson { get; set; }
    public bool WasAllowed { get; set; }
    public string? RejectionReason { get; set; }
    public decimal RiskScore { get; set; }
    public DateTime ActionTimestamp { get; set; } = DateTime.UtcNow;
}
