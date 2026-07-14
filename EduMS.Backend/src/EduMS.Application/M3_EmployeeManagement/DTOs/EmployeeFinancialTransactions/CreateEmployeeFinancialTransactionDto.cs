using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeFinancialTransactions;

public class CreateEmployeeFinancialTransactionDto
{
    public long EmployeeId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public string TransactionReferenceNumber { get; set; } = string.Empty;
    public int TransactionType { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "SAR";
    public DateTime TransactionDate { get; set; }
    public string DescriptionAr { get; set; } = string.Empty;
    public string? DescriptionEn { get; set; }
    public int ApprovalStatus { get; set; }
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Module5VoucherReference { get; set; }
    public string? Notes { get; set; }
}
