using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;

public class UpdateAcademicLockPeriodDto
{
    public long Id { get; set; }
    public long OfficeId { get; set; }
    public string PeriodName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool LockGradeRosters { get; set; }
    public bool LockEnrollmentSnapshots { get; set; }
    public bool LockPeriodStatisticalReports { get; set; }
    public bool LockAttendanceLogs { get; set; }
    public bool LockBehavioralRecords { get; set; }
    public bool LockFinancialFeeAssessments { get; set; }
    public string? UnlockReasonDescription { get; set; }
    public long? InitiatedByEmployeeId { get; set; }
}
