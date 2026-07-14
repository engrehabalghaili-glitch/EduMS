using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolSemesters;

public class CreateSchoolSemesterDto
{
    public long SchoolAcademicYearId { get; set; }
    public int SemesterNumber { get; set; }
    public string SemesterType { get; set; } = string.Empty;
    public string SemesterNameAr { get; set; } = string.Empty;
    public string? SemesterNameEn { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TeachingWeeksCount { get; set; }
    public int ExamWeeksCount { get; set; }
    public DateTime? RegistrationOpenDate { get; set; }
    public DateTime? RegistrationCloseDate { get; set; }
    public DateTime? AddDropStartDate { get; set; }
    public DateTime? AddDropEndDate { get; set; }
    public DateTime? ExamStartDate { get; set; }
    public DateTime? ExamEndDate { get; set; }
    public DateTime? GradingOpenDate { get; set; }
    public DateTime? GradingCloseDate { get; set; }
    public DateTime? ClosureDate { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public bool IsActive { get; set; }
    public bool IsCurrent { get; set; }
    public string? Notes { get; set; }
}
