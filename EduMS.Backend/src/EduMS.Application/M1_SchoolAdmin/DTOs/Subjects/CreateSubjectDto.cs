using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;

public class CreateSubjectDto
{
    public long SchoolId { get; set; }
    public string SubjectCode { get; set; }
    public string SubjectNameAr { get; set; }
    public string SubjectNameEn { get; set; }
    public string? Specialization { get; set; }
    public int WeeklyHours { get; set; }
    public int GradeLevel { get; set; }
    public string? TextbookTitle { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal PassingMarks { get; set; }
    public decimal CreditHours { get; set; }
    public bool IsCoreSubject { get; set; }
}
