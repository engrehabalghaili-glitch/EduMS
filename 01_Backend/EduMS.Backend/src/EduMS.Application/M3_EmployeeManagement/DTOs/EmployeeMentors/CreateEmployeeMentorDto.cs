using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMentors;

public class CreateEmployeeMentorDto
{
    public long MentorEmployeeId { get; set; }
    public long MenteeEmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public DateTime AssignmentDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? MentoringGoals { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
