using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.StatisticsReportsArchives;

public class StatisticsReportsArchiveDto
{
    public long Id { get; set; }
    public string SourceReportType { get; set; } = string.Empty;
    public long SourceReportId { get; set; }
    public long SchoolId { get; set; }
    public DateTime ArchivedAt { get; set; } = DateTime.UtcNow;
    public long ArchivedByUserId { get; set; }
    public int RetentionPeriodYears { get; set; } = 7;
    public DateTime? RetentionEndDate { get; set; }
    public string? FilePath { get; set; }
    public long FileSizeBytes { get; set; }
    public bool IsReadOnly { get; set; } = true;
    public DateTime? DisposalDate { get; set; }
    public int DisposalStatus { get; set; } = 1;
    public string? DisposalMethod { get; set; }
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
