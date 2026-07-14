using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.StatisticsArchives;

public class StatisticsArchiveDto
{
    public long Id { get; set; }
    public long SubmittedStatisticsId { get; set; }
    public long SchoolId { get; set; }
    public string ArchivedYear { get; set; } = string.Empty;
    public int PeriodType { get; set; }
    public DateTime ArchivedAt { get; set; } = DateTime.UtcNow;
    public long ArchivedByUserId { get; set; }
    public string? FinalDataSnapshotJson { get; set; }
    public string? StudentSnapshotJson { get; set; }
    public string? StaffSnapshotJson { get; set; }
    public int RetentionPeriodYears { get; set; } = 10;
    public DateTime? RetentionEndDate { get; set; }
    public bool IsReadOnly { get; set; } = true;
    public string? Notes { get; set; }
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
