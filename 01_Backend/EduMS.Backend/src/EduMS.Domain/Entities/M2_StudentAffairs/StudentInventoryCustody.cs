using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// عهدة الطالب من الكتب والأدوات والزي المدرسي - Student inventory custody log extracted from ZIP ERD StudentInventory table (lines 2200-2250).
/// Tracks delivery, return, damage, and loss of school-owned items assigned to the student per academic year.
/// </summary>
public class StudentInventoryCustody : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int ItemType { get; set; } // 1=Textbook, 2=SchoolUniform, 3=Stationery, 4=Device, 5=Other
    public string ItemCode { get; set; } = string.Empty;
    public string ItemNameAr { get; set; } = string.Empty;
    public string? ItemNameEn { get; set; }
    public int QuantityDelivered { get; set; } = 1;
    public int ConditionAtDelivery { get; set; } = 1; // 1=New, 2=Good, 3=UsedFair, 4=UsedPoor
    public string? ConditionNotes { get; set; }
    public DateTime DeliveryDate { get; set; }
    public long? DeliveredByEmployeeId { get; set; }
    public string ReceivedByName { get; set; } = string.Empty;
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public int ConditionAtReturn { get; set; } // 1=Good, 2=Damaged, 3=LostNotReturned
    public string? ReturnNotes { get; set; }
    public bool IsReturned { get; set; }
    public bool IsDamaged { get; set; }
    public string? DamageDescription { get; set; }
    public DateTime? DamageDiscoveredDate { get; set; }
    public bool IsLost { get; set; }
    public DateTime? LostReportedDate { get; set; }
    public decimal PenaltyAmount { get; set; }
    public int PenaltyStatus { get; set; } = 1; // 1=Due, 2=Paid, 3=Waived
    public DateTime? PenaltyPaidDate { get; set; }
    public bool IsExemptFromPenalty { get; set; }
    public string? ExemptionReason { get; set; }
    public bool ReplacementRequired { get; set; }
    public string? Notes { get; set; }
    public long? SchoolAssetId { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
    public virtual Employee? DeliveredByEmployee { get; set; }
    public virtual SchoolAsset? SchoolAsset { get; set; }
}
