using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.FacilityDepartmentAssignments;

public class CreateFacilityDepartmentAssignmentDto
{
    public long SchoolId { get; set; }
    public int FacilityType { get; set; }
    public long FacilityId { get; set; }
    public long? DepartmentId { get; set; }
    public long? ResponsibleEmployeeId { get; set; }
    public int AssignmentType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsShared { get; set; }
    public string? SharedWithDepartmentsJson { get; set; }
    public string? SharingScheduleJson { get; set; }
    public int Priority { get; set; } = 1;
    public int AssignmentStatus { get; set; } = 1;
    public string? Notes { get; set; }
}
