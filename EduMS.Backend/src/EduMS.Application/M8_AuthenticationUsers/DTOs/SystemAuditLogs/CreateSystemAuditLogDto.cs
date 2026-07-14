using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.SystemAuditLogs;

public class CreateSystemAuditLogDto
{
    public long? SchoolId { get; set; }
    public long UserId { get; set; }
    public string? UserRoleAtExecution { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
    public long? EntityId { get; set; }
    public string? OldValueJson { get; set; }
    public string? NewValueJson { get; set; }
    public string? ChangeSummary { get; set; }
    public string? TableName { get; set; }
    public string? FieldName { get; set; }
    public string? IpAddress { get; set; }
    public string? DeviceType { get; set; }
    public string? UserAgent { get; set; }
    public string? SessionId { get; set; }
    public string? AccessContextJson { get; set; }
    public string? Severity { get; set; }
    public decimal RiskScore { get; set; }
    public bool IsSuspicious { get; set; }
    public bool WasAllowed { get; set; } = true;
    public string? RejectionReason { get; set; }
    public string? Notes { get; set; }
    public DateTime ActionTimestamp { get; set; } = DateTime.UtcNow;
}
