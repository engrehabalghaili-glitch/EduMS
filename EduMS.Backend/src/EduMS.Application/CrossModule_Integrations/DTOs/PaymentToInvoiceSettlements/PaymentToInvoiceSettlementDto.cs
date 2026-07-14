using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.PaymentToInvoiceSettlements;

public class PaymentToInvoiceSettlementDto
{
    public long Id { get; set; }
    public long PaymentVoucherId { get; set; }
    public long FeeInvoiceId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public decimal AllocatedAmount { get; set; }
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
