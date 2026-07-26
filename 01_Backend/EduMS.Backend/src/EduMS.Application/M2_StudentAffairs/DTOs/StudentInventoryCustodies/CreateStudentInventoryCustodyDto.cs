using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentInventoryCustodies;

public class CreateStudentInventoryCustodyDto
{
    public long StudentId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int ItemType { get; set; }
    public string ItemCode { get; set; }
    public string ItemNameAr { get; set; }
    public string? ItemNameEn { get; set; }
    public int QuantityDelivered { get; set; }
    public int ConditionAtDelivery { get; set; }
    public string? ConditionNotes { get; set; }
    public DateTime DeliveryDate { get; set; }
    public long? DeliveredByEmployeeId { get; set; }
    public string ReceivedByName { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public int ConditionAtReturn { get; set; }
    public string? ReturnNotes { get; set; }
    public bool IsReturned { get; set; }
    public bool IsDamaged { get; set; }
    public string? DamageDescription { get; set; }
    public DateTime? DamageDiscoveredDate { get; set; }
    public bool IsLost { get; set; }
    public DateTime? LostReportedDate { get; set; }
    public decimal PenaltyAmount { get; set; }
    public DateTime? PenaltyPaidDate { get; set; }
    public bool IsExemptFromPenalty { get; set; }
    public string? ExemptionReason { get; set; }
    public bool ReplacementRequired { get; set; }
    public string? Notes { get; set; }
}
