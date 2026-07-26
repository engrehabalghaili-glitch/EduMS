using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.PurchaseOrders;

public class PurchaseOrderDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PoNumber { get; set; } = string.Empty;
    public DateTime PoDate { get; set; }
    public long? RequirementRequestId { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string? SupplierContact { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public string? PaymentTerms { get; set; }
    public DateTime? DeliveryDeadline { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int PoStatus { get; set; } = 1;
    public long? BudgetAllocationId { get; set; }
    public string? AttachmentUrl { get; set; }
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
