using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomResourceAllocations;

public class UpdateClassroomResourceAllocationDto
{
    public long Id { get; set; }
    public long ClassroomId { get; set; }
    public string ResourceNameAr { get; set; } = string.Empty;
    public string ResourceCode { get; set; } = string.Empty;
    public int ResourceType { get; set; }
    public int Quantity { get; set; }
    public DateTime AssignedDate { get; set; }
    public string? ConditionStatus { get; set; }
    public string? ResourceNameEn { get; set; }
    public string? AssetSerialNumber { get; set; }
    public decimal UnitPurchaseCost { get; set; }
    public DateTime? LastInspectionDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
}
