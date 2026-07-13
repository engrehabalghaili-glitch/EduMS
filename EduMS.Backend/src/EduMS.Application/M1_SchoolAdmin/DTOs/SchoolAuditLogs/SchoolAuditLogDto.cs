using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAuditLogs;

public class SchoolAuditLogDto
{
    public long Id { get; set; }
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
    public DateTime ActionDate { get; set; }
    public int SeverityLevel { get; set; }
    public bool IsSuspicious { get; set; }
    public string? DecisionDocumentUrl { get; set; }
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
