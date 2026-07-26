using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentDailyAttendanceSummaries;

public class UpdateStudentDailyAttendanceSummaryDto
{
    public long Id { get; set; }
    public string AcademicYear { get; set; }
    public int SemesterNumber { get; set; }
    public int MonthNumber { get; set; }
    public int TotalPresentDays { get; set; }
    public int TotalAbsentDays { get; set; }
    public int TotalExcusedDays { get; set; }
    public int TotalLateDays { get; set; }
    public decimal TotalAbsencePercentage { get; set; }
    public bool IsWarningThresholdReached { get; set; }
    public int ConsecutiveAbsentDaysCount { get; set; }
    public DateTime? LastAbsenceDate { get; set; }
    public bool IsParentNotifiedOfThreshold { get; set; }
    public int CalculatedGradeLevel { get; set; }
}
