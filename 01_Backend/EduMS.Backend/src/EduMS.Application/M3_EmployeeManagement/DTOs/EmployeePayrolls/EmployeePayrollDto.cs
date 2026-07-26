using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrolls;

public class EmployeePayrollDto
{
    public long Id { get; set; }
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
    public int PaymentStatus { get; set; } = 1;
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
    public string? BankTransactionRef { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public bool IsSynced { get; set; }
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
