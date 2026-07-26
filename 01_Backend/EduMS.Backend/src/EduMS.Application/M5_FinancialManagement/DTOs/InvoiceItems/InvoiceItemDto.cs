using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.InvoiceItems;

public class InvoiceItemDto
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public long FeeTypeId { get; set; }
    public string? ItemCode { get; set; }
    public string ItemDescription { get; set; } = string.Empty;
    public int Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal? DiscountPercentage { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal PriceAfterDiscount { get; set; }
    public decimal? TaxPercentage { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsPaid { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string? PaymentMethod { get; set; }
    public bool IsLate { get; set; }
    public bool LateFeeApplied { get; set; }
    public decimal? LateFeeAmount { get; set; }
    public int? InstallmentNumber { get; set; }
    public int? InstallmentTotal { get; set; }
    public bool IsWaived { get; set; }
    public string? WaiverReason { get; set; }
    public DateTime? WaiverDate { get; set; }
    public int Status { get; set; } = 1;
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
