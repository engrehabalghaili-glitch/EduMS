using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الفصول الدراسية للمدرسة - Semester definition extracted from ZIP ERD source (SchoolSemester table, lines 193-225).
/// </summary>
public class SchoolSemester : BaseAuditableEntity
{
    public long SchoolAcademicYearId { get; set; }
    public int SemesterNumber { get; set; }   // 1, 2, 3
    public string SemesterType { get; set; } = string.Empty; // First, Second, Third, Summer
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
    public int ApprovalStatus { get; set; } = 1; // 1=Draft, 2=PendingApproval, 3=Approved
    public bool IsActive { get; set; }
    public bool IsCurrent { get; set; }
    public string? Notes { get; set; }

    // Navigation Property
    public virtual SchoolAcademicYear? AcademicYear { get; set; }
}
