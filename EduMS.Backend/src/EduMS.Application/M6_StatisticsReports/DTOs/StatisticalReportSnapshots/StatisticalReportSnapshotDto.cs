using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.StatisticalReportSnapshots;

public class StatisticalReportSnapshotDto
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
