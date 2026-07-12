using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الاستلام الفعلي للأصل وفحص الجودة - Asset receiving and quality inspection extracted from ZIP ERD AssetReceiving table (lines 6936-6967).
/// </summary>
public class AssetReceiving : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long PurchaseOrderId { get; set; }
    public string ReceivingNumber { get; set; } = string.Empty;
    public DateTime ReceivedDate { get; set; }
    public long ReceivedByEmployeeId { get; set; }
    public long? InspectorEmployeeId { get; set; }
    public string? DeliveryNoteNumber { get; set; }
    public string? DeliveryCompany { get; set; }
    public int InspectionResult { get; set; } // 1=Conformant, 2=PartiallyConformant, 3=NonConformant, 4=Rejected
    public DateTime? InspectionDate { get; set; }
    public string? InspectionNotes { get; set; }
    public int DeliveryStatus { get; set; } // 1=FullyReceived, 2=Delayed, 3=PartiallyReceived
    public string? ReceivedItemsDetailsJson { get; set; }
    public string? RejectedItemsJson { get; set; }
    public bool ReturnRequested { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int FinalDecision { get; set; } // 1=FullAcceptance, 2=PartialAcceptanceWithDiscount, 3=FullRejection
    public string? AttachmentsJson { get; set; }
    public int ReceivingStatus { get; set; } = 1; // 1=Open, 2=UnderInspection, 3=Complete, 4=Cancelled
    public string? Notes { get; set; }

    public virtual PurchaseOrder? PurchaseOrder { get; set; }
}

/// <summary>
/// سجل استخدام الأصل اليومي - Asset usage log extracted from ZIP ERD AssetUsageLog table (lines 6969-6989).
/// </summary>
public class AssetUsageLog : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int UsageType { get; set; } // 1=NormalOperation, 2=Testing, 3=Maintenance, 4=Emergency
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public int DurationMinutes { get; set; }
    public int UsagePurpose { get; set; } // 1=Educational, 2=Administrative, 3=Training, 4=Meeting
    public string? PurposeDetails { get; set; }
    public long? UsedByUserId { get; set; }
    public int UserType { get; set; } // 1=Teacher, 2=Admin, 3=Student
    public long? LocationId { get; set; }
    public int UsageStatus { get; set; } // 1=InUse, 2=Completed, 3=Suspended, 4=Interrupted
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// تخصيص الميزانية للأصول - Asset budget allocation extracted from ZIP ERD AssetBudgetAllocation table (lines 6884-6902).
/// </summary>
public class AssetBudgetAllocation : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public int BudgetType { get; set; } // 1=Capital (Capex), 2=Operational (Opex)
    public long? AssetCategoryId { get; set; }
    public long? DepartmentId { get; set; }
    public decimal AllocatedAmount { get; set; }
    public decimal SpentAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string? BudgetLineCode { get; set; }
    public int AllocationStatus { get; set; } = 1; // 1=Active, 2=Exhausted, 3=Cancelled
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}
