using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.StudentAccounts;

public class StudentAccountDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal CurrentBalance { get; set; }
    public int BalanceType { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalExemption { get; set; }
    public DateTime? LastTransactionDate { get; set; }
    public DateTime? LastPaymentDate { get; set; }
    public decimal? LastPaymentAmount { get; set; }
    public int AccountStatus { get; set; } = 1;
    public bool IsExempt { get; set; }
    public decimal? ExemptionPercentage { get; set; }
    public string? ExemptionReason { get; set; }
    public long? ExemptionApprovedByUserId { get; set; }
    public DateTime? ExemptionApprovalDate { get; set; }
    public string? ExemptionDocumentUrl { get; set; }
    public decimal? MinimumPaymentRequired { get; set; }
    public bool IsBlockedFromRegistration { get; set; }
    public string? BlockReason { get; set; }
    public DateTime? UnblockDate { get; set; }
    public string? PaymentPlan { get; set; }
    public bool IsEligibleForExam { get; set; } = true;
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
