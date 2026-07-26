using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class ClassroomResourceAllocation : BaseAuditableEntity
{
    public long ClassroomId { get; set; }
    public string ResourceNameAr { get; set; } = string.Empty;
    public string ResourceCode { get; set; } = string.Empty;
    public int ResourceType { get; set; } // 1=Projector, 2=SmartBoard, 3=AirConditioner, 4=DeskSet
    public int Quantity { get; set; }
    public DateTime AssignedDate { get; set; } = DateTime.UtcNow;
    public string? ConditionStatus { get; set; }
    public string? ResourceNameEn { get; set; }
    public string? AssetSerialNumber { get; set; }
    public decimal UnitPurchaseCost { get; set; }
    public DateTime? LastInspectionDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }

    // Navigation Property
    public virtual Classroom? Classroom { get; set; }
}
