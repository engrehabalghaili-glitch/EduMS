using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.StatisticalReportSnapshots;

public class UpdateStatisticalReportSnapshotDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long? AcademicLockPeriodId { get; set; }
    public string ReportCode { get; set; } = string.Empty;
    public string ReportNameAr { get; set; } = string.Empty;
    public string ReportCategory { get; set; } = string.Empty;
    public string SnapshotPayloadJson { get; set; } = "{}";
    public DateTime SnapshotDate { get; set; } = DateTime.UtcNow;
    public bool IsVerifiedByOffice { get; set; } = false;
}
