using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// سجل فحص الأصل (استلام/إرجاع/دوري) - extracted from ZIP ERD AssetInspectionLog (lines 7481-7504).
/// </summary>
public class AssetInspectionLog : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public string RelatedTransactionType { get; set; } = string.Empty; // ReceivingFromSupplier, ReturnFromEmployee, Transfer, Periodic
    public long? RelatedTransactionId { get; set; }
    public int InspectionType { get; set; } // 1=AtReceiving, 2=AtReturn, 3=Periodic
    public DateTime InspectionDate { get; set; }
    public long InspectorUserId { get; set; }
    public int PhysicalCondition { get; set; } // 1=Intact, 2=MinorDamage, 3=PartialDamage, 4=TotalDamage, 5=Missing
    public string? DamageDetails { get; set; }
    public string? DamagePhotosJson { get; set; }
    public int FunctionalStatus { get; set; } // 1=FullyFunctional, 2=PartiallyFunctional, 3=NonFunctional
    public string? MissingPartsJson { get; set; }
    public int InspectionResult { get; set; } // 1=Accepted, 2=Rejected, 3=NeedsMaintenance, 4=NeedsReplacement
    public string? RecommendedAction { get; set; }
    public decimal EstimatedRepairCost { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// سجل حركة الأصل التاريخي الكامل - extracted from ZIP ERD AssetMovementHistory (lines 7506-7521).
/// </summary>
public class AssetMovementHistory : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public string ActionType { get; set; } = string.Empty; // Transfer, Assignment, Loan, Return, Maintenance, StatusChange, LocationChange, Purchase, WriteOff
    public string ActionDescription { get; set; } = string.Empty;
    public string? OldValueJson { get; set; }
    public string? NewValueJson { get; set; }
    public string? RelatedEntityType { get; set; }
    public long? RelatedEntityId { get; set; }
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;
    public long PerformedByUserId { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// تنبيهات متابعة إعارات الأصول المتأخرة - extracted from ZIP ERD LoanTrackingAlerts (lines 7523-7541).
/// </summary>
public class AssetLoanTrackingAlert : BaseAuditableEntity
{
    public long LoanId { get; set; }
    public long SchoolId { get; set; }
    public int AlertType { get; set; } // 1=ReminderBeforeExpiry, 2=OverdueNotice, 3=PenaltyAlert
    public DateTime AlertDate { get; set; }
    public string AlertMessageText { get; set; } = string.Empty;
    public int DeliveryMethod { get; set; } // 1=Email, 2=SMS, 3=AppNotification
    public bool IsSent { get; set; }
    public string? SentToContact { get; set; }
    public bool IsAcknowledged { get; set; }
    public DateTime? AcknowledgedAt { get; set; }
    public bool ViolationRecorded { get; set; }
    public long? ViolationId { get; set; }
    public string? Notes { get; set; }

    public virtual AssetLoan? Loan { get; set; }
}

/// <summary>
/// إشعارات الصيانة التلقائية - extracted from ZIP ERD MaintenanceNotifications (lines 7146-7166).
/// </summary>
public class MaintenanceNotification : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string RelatedEntityType { get; set; } = string.Empty;
    public long RelatedEntityId { get; set; }
    public int NotificationType { get; set; } // 1=NewTicket, 2=UpcomingMaintenance, 3=StockAlert, 4=MaintenanceComplete
    public string Title { get; set; } = string.Empty;
    public string MessageContent { get; set; } = string.Empty;
    public long RecipientUserId { get; set; }
    public int Priority { get; set; } // 1=Normal, 2=Important, 3=Urgent
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public int DeliveryMethod { get; set; } // 1=App, 2=Email, 3=SMS
    public int NotificationStatus { get; set; } = 1; // 1=Sent, 2=Read, 3=Cancelled
}
