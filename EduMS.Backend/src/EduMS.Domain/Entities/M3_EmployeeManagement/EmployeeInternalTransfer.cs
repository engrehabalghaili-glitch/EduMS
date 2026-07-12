using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// نقل الموظف الداخلي بين الأقسام - Internal department transfer extracted from ZIP ERD InternalTransfer table.
/// </summary>
public class EmployeeInternalTransfer : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long SchoolId { get; set; }
    public string TransferRequestNumber { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public long FromDepartmentId { get; set; }
    public long ToDepartmentId { get; set; }
    public string? FromJobTitle { get; set; }
    public string? ToJobTitle { get; set; }
    public string TransferReason { get; set; } = string.Empty;
    public DateTime? EffectiveDate { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Pending, 2=Approved, 3=Rejected, 4=Executed
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? RejectionReason { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
}
