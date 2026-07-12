using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentDailyAttendanceSummary : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int SemesterNumber { get; set; }
    public int MonthNumber { get; set; }
    public int TotalPresentDays { get; set; }
    public int TotalAbsentDays { get; set; }
    public int TotalExcusedDays { get; set; }
    public int TotalLateDays { get; set; }
    public decimal TotalAbsencePercentage { get; set; }
    public bool IsWarningThresholdReached { get; set; } = false;
    public int ConsecutiveAbsentDaysCount { get; set; }
    public DateTime? LastAbsenceDate { get; set; }
    public bool IsParentNotifiedOfThreshold { get; set; }
    public int CalculatedGradeLevel { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
}
