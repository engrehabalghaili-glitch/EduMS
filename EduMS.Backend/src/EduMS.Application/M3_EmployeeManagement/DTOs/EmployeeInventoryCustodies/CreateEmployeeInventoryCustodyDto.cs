using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInventoryCustodies;

public class CreateEmployeeInventoryCustodyDto
{
    public long EmployeeId { get; set; }
    public long? AssetId { get; set; }
    public string ItemType { get; set; } = string.Empty;
    public string ItemNameAr { get; set; } = string.Empty;
    public string? ItemBrand { get; set; }
    public string? ItemModel { get; set; }
    public string? ItemSerialNumber { get; set; }
    public string? ItemCode { get; set; }
    public decimal EstimatedValue { get; set; }
    public int ConditionAtHandover { get; set; }
    public DateTime HandoverDate { get; set; }
    public string? HandoverNotes { get; set; }
    public long? IssuedByEmployeeId { get; set; }
    public string? ReceiptSignatureUrl { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public int ConditionAtReturn { get; set; }
    public string? ReturnNotes { get; set; }
    public bool IsReturned { get; set; }
    public bool IsDamaged { get; set; }
    public string? DamageDescription { get; set; }
    public decimal PenaltyAmount { get; set; }
    public int PenaltyStatus { get; set; } = 1;
    public bool IsLost { get; set; }
    public bool ReplacementRequired { get; set; }
    public int CustodyStatus { get; set; } = 1;
    public string? Notes { get; set; }
}
