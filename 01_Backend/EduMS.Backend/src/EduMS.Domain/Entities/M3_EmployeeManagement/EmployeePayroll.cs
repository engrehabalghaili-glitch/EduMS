using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// كشف راتب الموظف الشهري - Employee payroll record extracted from ZIP ERD EmployeePayroll table.
/// </summary>
public class EmployeePayroll : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int PayrollMonth { get; set; }
    public int PayrollYear { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal HousingAllowance { get; set; }
    public decimal TransportAllowance { get; set; }
    public decimal OtherAllowances { get; set; }
    public decimal OvertimePay { get; set; }
    public decimal GrossTotal { get; set; }
    public decimal DeductionAbsence { get; set; }
    public decimal DeductionInsurance { get; set; }
    public decimal DeductionOther { get; set; }
    public decimal NetSalary { get; set; }
    public int PaymentStatus { get; set; } = 1; // 1=Pending, 2=Paid, 3=Held, 4=Reversed
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; } // BankTransfer, Cash, Cheque
    public string? BankTransactionRef { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public bool IsSynced { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
    public virtual EmployeePayrollFinancialContract? FinancialContract { get; set; }
}
