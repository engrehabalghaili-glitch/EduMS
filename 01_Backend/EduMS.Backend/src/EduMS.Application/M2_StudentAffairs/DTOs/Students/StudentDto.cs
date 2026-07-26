using System;
using EduMS.Application.M2_StudentAffairs.DTOs.Persons;

namespace EduMS.Application.M2_StudentAffairs.DTOs.Students;

public class StudentDto : PersonDto
{
    public string EnrollmentNumber { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public long? SchoolId { get; set; }
    public long? ClassroomId { get; set; }
    public long? GuardianId { get; set; }
    public string? PreviousSchoolName { get; set; }
    public int AdmissionGradeLevel { get; set; }
    public string? CurrentAcademicYear { get; set; }
    public int StudentStatus { get; set; }
    public string? SpecialEducationNeeds { get; set; }
    public string? BusStopLocationDescription { get; set; }
    public bool IsActive { get; set; }
}
