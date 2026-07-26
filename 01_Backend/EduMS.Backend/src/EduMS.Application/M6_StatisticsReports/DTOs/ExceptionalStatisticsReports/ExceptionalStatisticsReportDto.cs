using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.ExceptionalStatisticsReports;

public class ExceptionalStatisticsReportDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public int TotalIncidents { get; set; }
    public int TotalClosureDays { get; set; }
    public decimal TotalDamageCost { get; set; }
    public int TotalAwardsCount { get; set; }
    public int TotalParticipationsCount { get; set; }
    public int TotalDeficitCount { get; set; }
    public int TotalSurplusCount { get; set; }
    public string? EmergencySummaryJson { get; set; }
    public string? ClosureSummaryJson { get; set; }
    public string? AwardSummaryJson { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? GeneratedByUserId { get; set; }
    public string? FilePath { get; set; }
    public int ReportStatus { get; set; } = 1;
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
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
