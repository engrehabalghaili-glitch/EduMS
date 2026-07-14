using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.PurchaseOrders;

public class CreatePurchaseOrderDto
{
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
}
