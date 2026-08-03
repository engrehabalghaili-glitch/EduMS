using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// سجل التغييرات والتدقيق المدرسي - School-level audit trail extracted from ZIP ERD SchoolAuditLog table (lines 304-326).
/// Records every Add/Edit/Delete event on critical school entities with user, IP and severity tracking.
/// </summary>
public class SchoolAuditLog : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string AffectedTableName { get; set; } = string.Empty;  // e.g. "Students", "Employees"
    public long AffectedEntityId { get; set; }
    public int OperationType { get; set; } // 1=Insert, 2=Update, 3=Delete, 4=Restore
    public string ChangeTypeSummary { get; set; } = string.Empty;   // Human-readable change label
    public string? OldValueJson { get; set; }
    public string? NewValueJson { get; set; }
    public string ChangeSummaryText { get; set; } = string.Empty;
    public long PerformedByUserId { get; set; }
    public string PerformedByUserName { get; set; } = string.Empty;
    public string PerformedByUserRole { get; set; } = string.Empty;
    public string? IpAddress { get; set; }
    public string? DeviceInfo { get; set; }
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;
    public int SeverityLevel { get; set; } = 1; // 1=Info, 2=Warning, 3=Critical
    public bool IsSuspicious { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public string? Notes { get; set; }

    // Navigation Property
    public virtual School? School { get; set; }
}
