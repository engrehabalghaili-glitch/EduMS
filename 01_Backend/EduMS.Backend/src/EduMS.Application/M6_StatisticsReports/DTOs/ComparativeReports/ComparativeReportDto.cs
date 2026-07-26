using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.ComparativeReports;

public class ComparativeReportDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public string ComparisonTitle { get; set; } = string.Empty;
    public string FirstPeriodLabel { get; set; } = string.Empty;
    public string FirstPeriodStart { get; set; } = string.Empty;
    public string FirstPeriodEnd { get; set; } = string.Empty;
    public string SecondPeriodLabel { get; set; } = string.Empty;
    public string SecondPeriodStart { get; set; } = string.Empty;
    public string SecondPeriodEnd { get; set; } = string.Empty;
    public string ComparisonType { get; set; } = string.Empty;
    public string? KpiComparedJson { get; set; }
    public string? ComparisonDataJson { get; set; }
    public string? AutoInsights { get; set; }
    public string? Summary { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? GeneratedByUserId { get; set; }
    public string? FileFormat { get; set; }
    public string? FilePath { get; set; }
    public int ViewCount { get; set; }
    public DateTime? LastViewedAt { get; set; }
    public int ReportStatus { get; set; } = 1;
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
