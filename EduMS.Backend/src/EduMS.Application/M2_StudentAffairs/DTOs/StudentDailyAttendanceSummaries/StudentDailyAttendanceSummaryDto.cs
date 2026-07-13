using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentDailyAttendanceSummaries;

public class StudentDailyAttendanceSummaryDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
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

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
