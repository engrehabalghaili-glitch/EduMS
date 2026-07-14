using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilities;

public class CreateSchoolFacilityDto
{
    public long SchoolId { get; set; }
    public string FacilityCode { get; set; } = string.Empty;
    public string FacilityNameAr { get; set; } = string.Empty;
    public string FacilityNameEn { get; set; } = string.Empty;
    public int FacilityType { get; set; }
    public int Capacity { get; set; }
    public long? AssignedSupervisorId { get; set; }
    public bool IsOperational { get; set; } = true;
    public string? LocationFloor { get; set; }
    public string? BuildingName { get; set; }
    public DateTime? SafetyInspectionDate { get; set; }
    public int MaintenanceStatus { get; set; } = 1;
}
