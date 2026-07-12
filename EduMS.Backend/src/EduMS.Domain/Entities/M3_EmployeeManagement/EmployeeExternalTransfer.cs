using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// نقل الموظف الخارجي بين المدارس - External school-to-school transfer extracted from ZIP ERD ExternalTransfer table.
/// </summary>
public class EmployeeExternalTransfer : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long FromSchoolId { get; set; }
    public long? ToSchoolId { get; set; }
    public string TransferRequestNumber { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public int TransferDirection { get; set; } // 1=Outgoing, 2=Incoming, 3=Secondment, 4=Delegation
    public string TransferReason { get; set; } = string.Empty;
    public DateTime? EffectiveDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? MinistryDecisionNumber { get; set; }
    public DateTime? MinistryDecisionDate { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Pending, 2=Approved, 3=Rejected, 4=Executed
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
}
