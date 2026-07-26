using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.ExceptionalStatisticsReports;

public class UpdateExceptionalStatisticsReportDto
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
}
