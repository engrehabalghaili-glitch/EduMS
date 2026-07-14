using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeFinancialTransactions;

public class EmployeeFinancialTransactionDto
{
    public long Id { get; set; }
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
