using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.StatisticsReportsArchives;

public class UpdateStatisticsReportsArchiveDto
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
}
