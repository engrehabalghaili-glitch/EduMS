using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StatisticalReportSnapshot : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? AcademicLockPeriodId { get; set; }
    public string ReportCode { get; set; } = string.Empty; // e.g. "ANNUAL_COMPREHENSIVE_REPORT"
    public string ReportNameAr { get; set; } = string.Empty;
    public string ReportCategory { get; set; } = string.Empty; // e.g. "KPI_METRICS", "FINANCIAL_SUMMARY"
    public string SnapshotPayloadJson { get; set; } = "{}";
    public DateTime SnapshotDate { get; set; } = DateTime.UtcNow;
    public bool IsVerifiedByOffice { get; set; } = false;

    // Cross-Module Navigation Properties
    public virtual School? School { get; set; }
    public virtual AcademicLockPeriod? AcademicLockPeriod { get; set; }
}
