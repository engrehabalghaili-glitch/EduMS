using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الحركة المالية للموظف - Employee Financial Transaction (M3 Universal Ledger Record).
/// Captures all non-regular-salary HR financial claims, allowances, loans, and reimbursements
/// for universal sector employees, ready for Module 5 ledger processing.
/// </summary>
public class EmployeeFinancialTransaction : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public string TransactionReferenceNumber { get; set; } = string.Empty;
    public int TransactionType { get; set; } // 1=SalaryAdvance, 2=TrainingReimbursement, 3=TravelAllowance, 4=MedicalClaim, 5=LoanDisbursement, 6=EndServiceSettlement
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "SAR";
    public DateTime TransactionDate { get; set; }
    public string DescriptionAr { get; set; } = string.Empty;
    public string? DescriptionEn { get; set; }
    public int ApprovalStatus { get; set; } // 1=Draft, 2=HrApproved, 3=FinancialPending, 4=Disbursed, 5=Rejected
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Module5VoucherReference { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual Employee? Employee { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual Employee? ApprovedByEmployee { get; set; }
}
