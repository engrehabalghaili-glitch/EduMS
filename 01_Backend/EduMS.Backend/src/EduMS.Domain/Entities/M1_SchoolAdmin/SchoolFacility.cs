using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolFacility : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string FacilityCode { get; set; } = string.Empty;
    public string FacilityNameAr { get; set; } = string.Empty;
    public string FacilityNameEn { get; set; } = string.Empty;
    public int FacilityType { get; set; } // 1=Laboratory, 2=Library, 3=SportsHall, 4=Auditorium, 5=Canteen
    public int Capacity { get; set; }
    public long? AssignedSupervisorId { get; set; }
    public bool IsOperational { get; set; } = true;
    public string? LocationFloor { get; set; }
    public string? BuildingName { get; set; }
    public DateTime? SafetyInspectionDate { get; set; }
    public int MaintenanceStatus { get; set; } = 1; // 1=Good, 2=NeedsMaintenance, 3=UnderRepair

    // Navigation Property
    public virtual School? School { get; set; }
    public virtual Employee? AssignedSupervisor { get; set; }
}
