using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// طلب الاحتياج والمشتريات - Asset requirement request and purchase orders extracted from ZIP ERD tables (lines 6785-6934).
/// </summary>
public class AssetRequirementRequest : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string RequestNumber { get; set; } = string.Empty; // REQ-2024-001
    public int RequestType { get; set; } // 1=NewNeed, 2=Replacement, 3=CapacityIncrease, 4=Emergency
    public string AssetTypeDescription { get; set; } = string.Empty;
    public long? AssetCategoryId { get; set; }
    public int QuantityRequested { get; set; }
    public decimal EstimatedUnitCost { get; set; }
    public decimal EstimatedTotalCost { get; set; }
    public int Priority { get; set; } // 1=Urgent, 2=High, 3=Normal, 4=Low
    public string? UrgencyReason { get; set; }
    public long? RequestingDepartmentId { get; set; }
    public long? RequestedByEmployeeId { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public string? Justification { get; set; }
    public string? InitialSpecsText { get; set; }
    public DateTime? RequiredByDate { get; set; }
    public bool IsReplacement { get; set; }
    public long? AssetToReplaceId { get; set; }
    public string? ReplacementReason { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Draft, 2=UnderReview, 3=Approved, 4=Rejected, 5=ConvertedToPO
    public string? RejectionReason { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public bool ConvertedToPurchaseOrder { get; set; }
    public long? PurchaseOrderId { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// أمر الشراء - Purchase order extracted from ZIP ERD PurchaseOrders table (lines 6904-6934).
/// </summary>
public class PurchaseOrder : BaseAuditableEntity
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
    public int PoStatus { get; set; } = 1; // 1=Draft, 2=Approved, 3=SentToSupplier, 4=InProgress, 5=PartiallyReceived, 6=FullyReceived, 7=Cancelled
    public long? BudgetAllocationId { get; set; }
    public string? AttachmentUrl { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}
