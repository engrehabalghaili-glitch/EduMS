using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetLoans;

public class UpdateAssetLoanDto
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
}
