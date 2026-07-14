using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAuditLogs;

public class CreateSchoolAuditLogDto
{
    public long SchoolId { get; set; }
    public string AffectedTableName { get; set; } = string.Empty;
    public long AffectedEntityId { get; set; }
    public int OperationType { get; set; }
    public string ChangeTypeSummary { get; set; } = string.Empty;
    public string? OldValueJson { get; set; }
    public string? NewValueJson { get; set; }
    public string ChangeSummaryText { get; set; } = string.Empty;
    public long PerformedByUserId { get; set; }
    public string PerformedByUserName { get; set; } = string.Empty;
    public string PerformedByUserRole { get; set; } = string.Empty;
    public string? IpAddress { get; set; }
    public string? DeviceInfo { get; set; }
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;
    public int SeverityLevel { get; set; } = 1;
    public bool IsSuspicious { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public string? Notes { get; set; }
}
