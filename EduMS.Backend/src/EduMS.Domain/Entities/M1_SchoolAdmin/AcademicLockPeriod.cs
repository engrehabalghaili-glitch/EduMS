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
}
