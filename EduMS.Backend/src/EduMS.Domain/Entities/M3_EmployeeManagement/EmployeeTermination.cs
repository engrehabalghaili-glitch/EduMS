using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// إنهاء خدمة الموظف - Employee service termination extracted from ZIP ERD EmployeeTermination table.
/// </summary>
public class EmployeeTermination : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string TerminationReferenceNumber { get; set; } = string.Empty;
    public DateTime TerminationDate { get; set; }
    public int TerminationType { get; set; } // 1=Resignation, 2=Retirement, 3=Dismissal, 4=EndOfContract, 5=Death
    public string TerminationReason { get; set; } = string.Empty;
    public DateTime? LastWorkingDay { get; set; }
    public bool CustodyCleared { get; set; }
    public DateTime? CustodyClearanceDate { get; set; }
    public bool FinancialCleared { get; set; }
    public DateTime? FinancialClearanceDate { get; set; }
    public decimal GratuityAmount { get; set; }
    public decimal FinalSalarySettlement { get; set; }
    public string? DecisionDocumentUrl { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int TerminationStatus { get; set; } = 1; // 1=Initiated, 2=PendingClearance, 3=Completed, 4=Cancelled
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}
