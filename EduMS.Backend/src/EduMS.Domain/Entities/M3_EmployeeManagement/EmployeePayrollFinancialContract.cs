using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// عقد الارتباط المالي للرواتب - Employee Payroll Financial Contract (M3 to M5 Bridge).
/// Establishes the clean relational contract between HR payroll generation (Module 3)
/// and enterprise ledger disbursement, budget allocation, and cost center accounting (Module 5).
/// </summary>
public class EmployeePayrollFinancialContract : BaseAuditableEntity
{
    public long EmployeePayrollId { get; set; }
    public long EmployeeId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string FinancialTransactionReferenceNumber { get; set; } = string.Empty; // e.g. FIN-PAY-2026-0012
    public string CostCenterCode { get; set; } = string.Empty;
    public string BudgetLineCode { get; set; } = string.Empty;
    public decimal TotalGrossAmount { get; set; }
    public decimal TotalDeductionsAmount { get; set; }
    public decimal NetDisbursementAmount { get; set; }
    public string Currency { get; set; } = "SAR";
    public int DisbursementStatus { get; set; } = 1; // 1=PendingBudgetApproval, 2=Allocated, 3=Disbursed, 4=Rejected
    public DateTime? DisbursementDate { get; set; }
    public string? BankTransferReference { get; set; }
    public long? FinancialAuditorEmployeeId { get; set; }
    public string? FinancialAuditNotes { get; set; }

    // Navigation Properties
    public virtual EmployeePayroll? EmployeePayroll { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
    public virtual Employee? FinancialAuditorEmployee { get; set; }
}
