using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;

public class CreateSubjectDto
{
    public long SchoolId { get; set; }
    public string SubjectCode { get; set; } = string.Empty;
    public string SubjectNameAr { get; set; } = string.Empty;
    public string SubjectNameEn { get; set; } = string.Empty;
    public string? Specialization { get; set; }
    public int WeeklyHours { get; set; }
    public int GradeLevel { get; set; }
    public string? TextbookTitle { get; set; }
    public decimal TotalMarks { get; set; } = 100.0m;
    public decimal PassingMarks { get; set; } = 50.0m;
    public decimal CreditHours { get; set; } = 3.0m;
    public bool IsCoreSubject { get; set; } = true;
    public bool IsActive { get; set; } = true;
}
