using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// ملخص عهدة الموظف الكلية - Staff custody summary extracted from ZIP ERD StaffCustody table.
/// One-to-one with Employee; provides clearance status and aggregate custody value.
/// </summary>
public class StaffCustodySummary : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public string? CustodySummaryJson { get; set; }
    public decimal TotalItemsCount { get; set; }
    public decimal TotalEstimatedValue { get; set; }
    public DateTime? CustodyIssuedDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public int CustodyStatus { get; set; } = 1; // 1=ActiveWithEmployee, 2=Cleared, 3=PendingSettlement
    public DateTime? ClearanceDate { get; set; }
    public long? ClearedByUserId { get; set; }
    public string? ClearanceNotes { get; set; }
    public string? ClearanceDocumentUrl { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
}
