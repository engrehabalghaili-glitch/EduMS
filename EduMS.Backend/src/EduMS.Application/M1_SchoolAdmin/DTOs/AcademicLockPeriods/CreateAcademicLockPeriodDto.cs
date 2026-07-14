using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;

public class CreateAcademicLockPeriodDto
{
    public long OfficeId { get; set; }
    public long SchoolId { get; set; }
    public string PeriodName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool LockGradeRosters { get; set; } = true;
    public bool LockEnrollmentSnapshots { get; set; } = true;
    public bool LockPeriodStatisticalReports { get; set; } = true;
    public bool LockAttendanceLogs { get; set; } = true;
    public bool LockBehavioralRecords { get; set; } = true;
    public bool LockFinancialFeeAssessments { get; set; } = true;
    public string? UnlockReasonDescription { get; set; }
    public long? InitiatedByEmployeeId { get; set; }
}
