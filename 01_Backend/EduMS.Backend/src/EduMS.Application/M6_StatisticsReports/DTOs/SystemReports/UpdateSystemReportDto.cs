using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.SystemReports;

public class UpdateSystemReportDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ReportType { get; set; } = string.Empty;
    public string? ReportSubType { get; set; }
    public string ReportTitle { get; set; } = string.Empty;
    public int ReportFrequency { get; set; }
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public int GenerationMethod { get; set; }
    public long? GeneratedByUserId { get; set; }
    public string? FileFormat { get; set; }
    public string? FilePath { get; set; }
    public long FileSizeBytes { get; set; }
    public int ReportStatus { get; set; } = 1;
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public long? PublishedByUserId { get; set; }
    public int ViewCount { get; set; }
    public DateTime? LastViewedAt { get; set; }
    public string? Notes { get; set; }
}
