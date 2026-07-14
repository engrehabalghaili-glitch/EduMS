using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilities;

public class UpdateSchoolFacilityDto
{
    public long Id { get; set; }
    public string FacilityCode { get; set; }
    public string FacilityNameAr { get; set; }
    public string FacilityNameEn { get; set; }
    public int FacilityType { get; set; }
    public int Capacity { get; set; }
    public long? AssignedSupervisorId { get; set; }
    public bool IsOperational { get; set; }
    public string? LocationFloor { get; set; }
    public string? BuildingName { get; set; }
    public DateTime? SafetyInspectionDate { get; set; }
}
