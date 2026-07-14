using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetLoans;

public class AssetLoanDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int BorrowerType { get; set; }
    public long BorrowerId { get; set; }
    public string BorrowerName { get; set; } = string.Empty;
    public string? BorrowerContact { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public string? LoanPurpose { get; set; }
    public long? IssuerUserId { get; set; }
    public int ConditionAtLoan { get; set; }
    public int ConditionAtReturn { get; set; }
    public bool IsOverdue { get; set; }
    public int OverdueDays { get; set; }
    public decimal FineAmount { get; set; }
    public bool IsFinePaid { get; set; }
    public DateTime? FinePaidDate { get; set; }
    public int LoanStatus { get; set; } = 1;
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
