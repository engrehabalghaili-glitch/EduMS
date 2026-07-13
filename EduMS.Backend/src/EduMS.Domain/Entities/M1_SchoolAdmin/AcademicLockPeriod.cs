using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class AcademicLockPeriod : BaseAuditableEntity
{
    public long OfficeId { get; set; } // The office initiating the lock
    public long SchoolId { get; set; } // The school being locked
    public string PeriodName { get; set; } = string.Empty; // e.g. "2026_Semester1_FinalReviews"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;

    // Granular Lock Parameters (Selective locking controls)
    public bool LockGradeRosters { get; set; } = true;
    public bool LockEnrollmentSnapshots { get; set; } = true;
    public bool LockPeriodStatisticalReports { get; set; } = true;
    public bool LockAttendanceLogs { get; set; } = true;
    public bool LockBehavioralRecords { get; set; } = true;
    public bool LockFinancialFeeAssessments { get; set; } = true;
    public string? UnlockReasonDescription { get; set; }
    public long? InitiatedByEmployeeId { get; set; }

    // Cross-Module Navigation Properties
    public virtual School? School { get; set; }
    public virtual Employee? InitiatedByEmployee { get; set; }
    public virtual ICollection<StatisticalReportSnapshot> StatisticalReportSnapshots { get; set; } = new List<StatisticalReportSnapshot>();
}
