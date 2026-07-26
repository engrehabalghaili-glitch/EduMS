using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// بلاغ عطل الأصل - Asset breakdown/maintenance ticket extracted from ZIP ERD MaintenanceTickets (lines 6991-7024).
/// </summary>
public class AssetMaintenanceTicket : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string TicketNumber { get; set; } = string.Empty; // MT-2024-001
    public long AssetId { get; set; }
    public long ReportedByUserId { get; set; }
    public DateTime ReportDate { get; set; } = DateTime.UtcNow;
    public int IssueType { get; set; } // 1=Electrical, 2=Mechanical, 3=Software, 4=Structural, 5=Leak, 6=Other
    public int SeverityLevel { get; set; } // 1=Low, 2=Medium, 3=High, 4=Emergency
    public string IssueDescriptionText { get; set; } = string.Empty;
    public long? AssignedToEmployeeId { get; set; }
    public DateTime? AssignedDate { get; set; }
    public string? Diagnosis { get; set; }
    public decimal EstimatedCost { get; set; }
    public DateTime? EstimatedCompletionDate { get; set; }
    public DateTime? ActualCompletionDate { get; set; }
    public string? ResolutionDetails { get; set; }
    public decimal ResolutionCost { get; set; }
    public int TicketStatus { get; set; } = 1; // 1=Open, 2=UnderReview, 3=Approved, 4=InProgress, 5=AwaitingParts, 6=Completed, 7=Cancelled
    public long? ClosedByUserId { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// جدول الصيانة الوقائية - Preventive maintenance schedule extracted from ZIP ERD PreventiveMaintenanceSchedule (lines 7026-7056).
/// </summary>
public class PreventiveMaintenanceSchedule : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ScheduleCode { get; set; } = string.Empty;
    public long? AssetId { get; set; }
    public long? AssetCategoryId { get; set; }
    public string TaskNameAr { get; set; } = string.Empty;
    public string? TaskNameEn { get; set; }
    public int MaintenanceType { get; set; } // 1=Cleaning, 2=Calibration, 3=Inspection, 4=Lubrication, 5=PartsReplacement
    public int FrequencyUnit { get; set; } // 1=Week, 2=Month, 3=Quarter, 4=Year, 5=OperatingHours
    public decimal FrequencyValue { get; set; }
    public DateTime? NextDueDate { get; set; }
    public DateTime? LastServiceDate { get; set; }
    public int EstimatedDurationMinutes { get; set; }
    public string? AssignedToTeamText { get; set; }
    public string? InstructionsText { get; set; }
    public string? ChecklistJson { get; set; }
    public decimal EstimatedCost { get; set; }
    public long? MaintenanceContractId { get; set; }
    public bool IsReminderActive { get; set; } = true;
    public int ReminderDaysBefore { get; set; } = 7;
    public int ScheduleStatus { get; set; } = 1; // 1=Active, 2=Suspended, 3=Cancelled
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// تنفيذ أعمال الصيانة - Maintenance execution record extracted from ZIP ERD MaintenanceExecution (lines 7058-7083).
/// </summary>
public class MaintenanceExecution : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ExecutionNumber { get; set; } = string.Empty;
    public long? MaintenanceTicketId { get; set; }
    public long? PreventiveScheduleId { get; set; }
    public long AssetId { get; set; }
    public int ExecutionType { get; set; } // 1=Reactive, 2=Preventive, 3=Emergency
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public long ExecutedByEmployeeId { get; set; }
    public string WorkPerformedDescription { get; set; } = string.Empty;
    public string? SparePartsUsedJson { get; set; }
    public decimal MaintenanceCost { get; set; }
    public bool IsOperationalAfterMaintenance { get; set; }
    public long? NewAssetStatusId { get; set; }
    public string? ResolutionSummary { get; set; }
    public string? AttachmentsJson { get; set; }
    public int ExecutionStatus { get; set; } = 1; // 1=Completed, 2=InProgress, 3=Cancelled
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// قطع الغيار والمستهلكات في المستودع - Maintenance spare parts stock extracted from ZIP ERD MaintenanceSpareParts (lines 7085-7113).
/// </summary>
public class MaintenanceSparePart : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PartCode { get; set; } = string.Empty;   // SKU
    public string PartNameAr { get; set; } = string.Empty;
    public string? PartNameEn { get; set; }
    public string? PartCategory { get; set; } // Electrical, Mechanical, Electronic, Consumable
    public string? Manufacturer { get; set; }
    public string? CompatibleAssetsJson { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty; // Piece, Box, Liter, Meter
    public int CurrentStockQuantity { get; set; }
    public int MinStockLevel { get; set; }
    public int MaxStockLevel { get; set; }
    public int ReorderQuantity { get; set; }
    public decimal UnitCost { get; set; }
    public string? SupplierName { get; set; }
    public string? LocationInWarehouse { get; set; }
    public bool IsActive { get; set; } = true;
    public int StockStatus { get; set; } = 1; // 1=Available, 2=LowStock, 3=OutOfStock, 4=OnOrder
    public DateTime? LastRestockDate { get; set; }
    public decimal TotalConsumed { get; set; }
    public string? Notes { get; set; }
}
