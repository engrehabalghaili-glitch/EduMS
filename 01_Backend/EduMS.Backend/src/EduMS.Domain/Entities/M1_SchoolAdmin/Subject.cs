using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Subject : BaseAuditableEntity
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

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
    public virtual ICollection<StudentAssessment> StudentAssessments { get; set; } = new List<StudentAssessment>();
    public virtual ICollection<CurriculumTextbookDistribution> TextbookDistributions { get; set; } = new List<CurriculumTextbookDistribution>();
    public virtual ICollection<ExamDistributionTimetable> ExamTimetables { get; set; } = new List<ExamDistributionTimetable>();
    public virtual ICollection<DetailedAcademicWarningLog> DetailedAcademicWarningLogs { get; set; } = new List<DetailedAcademicWarningLog>();
    public virtual ICollection<StudentAssignmentSubmission> AssignmentSubmissions { get; set; } = new List<StudentAssignmentSubmission>();
}
