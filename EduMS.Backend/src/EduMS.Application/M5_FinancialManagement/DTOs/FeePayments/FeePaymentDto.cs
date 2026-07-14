using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.FeePayments;

public class FeePaymentDto
{
    public long Id { get; set; }
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? InvoiceId { get; set; }
    public long? InstallmentId { get; set; }
    public string PaymentNumber { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public DateTime? PaymentTime { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "SAR";
    public decimal ExchangeRate { get; set; } = 1.0m;
    public decimal ConvertedAmount { get; set; }
    public int PaymentMethod { get; set; }
    public string? PaymentType { get; set; }
    public string? BankName { get; set; }
    public string? BankTransactionId { get; set; }
    public string? CheckNumber { get; set; }
    public string? CheckBank { get; set; }
    public DateTime? CheckDate { get; set; }
    public string? CreditCardLast4 { get; set; }
    public string? CreditCardType { get; set; }
    public string? WalletType { get; set; }
    public string? PayerName { get; set; }
    public string? PayerType { get; set; }
    public string? PayerEmail { get; set; }
    public string ReceiptNumber { get; set; } = string.Empty;
    public bool ReceiptPrinted { get; set; }
    public bool ReceiptSentToEmail { get; set; }
    public DateTime? ReceiptEmailSentAt { get; set; }
    public string? ReceiptDocumentUrl { get; set; }
    public int PaymentStatus { get; set; } = 1;
    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmationDate { get; set; }
    public long? ConfirmedByUserId { get; set; }
    public bool IsReversed { get; set; }
    public DateTime? ReversalDate { get; set; }
    public string? ReversalReason { get; set; }
    public string? AllocatedInvoicesJson { get; set; }
    public string? AllocatedItemsJson { get; set; }
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
