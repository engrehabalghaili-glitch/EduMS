using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;

public class UpdateSubjectDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string SubjectCode { get; set; } = string.Empty;
    public string SubjectNameAr { get; set; } = string.Empty;
    public string SubjectNameEn { get; set; } = string.Empty;
    public string? Specialization { get; set; }
    public int WeeklyHours { get; set; }
    public int GradeLevel { get; set; }
    public string? TextbookTitle { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal PassingMarks { get; set; }
    public decimal CreditHours { get; set; }
    public bool IsCoreSubject { get; set; }
    public bool IsActive { get; set; }
}
