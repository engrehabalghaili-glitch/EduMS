using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// عهدة الموظف من أصول المدرسة - Employee inventory custody log extracted from ZIP ERD EmployeeInventoryCustody table.
/// </summary>
public class EmployeeInventoryCustody : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? AssetId { get; set; }
    public string ItemType { get; set; } = string.Empty; // Laptop, Tablet, Keys, Uniform, Books
    public string ItemNameAr { get; set; } = string.Empty;
    public string? ItemBrand { get; set; }
    public string? ItemModel { get; set; }
    public string? ItemSerialNumber { get; set; }
    public string? ItemCode { get; set; }
    public decimal EstimatedValue { get; set; }
    public int ConditionAtHandover { get; set; } // 1=New, 2=Good, 3=UsedFair, 4=NeedsMaintenance
    public DateTime HandoverDate { get; set; }
    public string? HandoverNotes { get; set; }
    public long? IssuedByEmployeeId { get; set; }
    public string? ReceiptSignatureUrl { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public int ConditionAtReturn { get; set; } // 1=Good, 2=Damaged, 3=Lost
    public string? ReturnNotes { get; set; }
    public bool IsReturned { get; set; }
    public bool IsDamaged { get; set; }
    public string? DamageDescription { get; set; }
    public decimal PenaltyAmount { get; set; }
    public int PenaltyStatus { get; set; } = 1; // 1=Due, 2=Paid, 3=Waived
    public bool IsLost { get; set; }
    public bool ReplacementRequired { get; set; }
    public int CustodyStatus { get; set; } = 1; // 1=Active, 2=Returned, 3=Lost, 4=Damaged
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
}
