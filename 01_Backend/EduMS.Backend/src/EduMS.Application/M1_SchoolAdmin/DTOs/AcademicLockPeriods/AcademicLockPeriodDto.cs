using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;

public class AcademicLockPeriodDto
{
    public long Id { get; set; }
    public long OfficeId { get; set; }
    public long SchoolId { get; set; }
    public string PeriodName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public bool LockGradeRosters { get; set; }
    public bool LockEnrollmentSnapshots { get; set; }
    public bool LockPeriodStatisticalReports { get; set; }
    public bool LockAttendanceLogs { get; set; }
    public bool LockBehavioralRecords { get; set; }
    public bool LockFinancialFeeAssessments { get; set; }
    public string? UnlockReasonDescription { get; set; }
    public long? InitiatedByEmployeeId { get; set; }

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
