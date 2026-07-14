using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.SchoolStatisticsDrafts;

public class CreateSchoolStatisticsDraftDto
{
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public int PeriodType { get; set; }
    public int PeriodValue { get; set; }
    public DateTime PeriodStartDate { get; set; }
    public DateTime PeriodEndDate { get; set; }
    public string DraftNumber { get; set; } = string.Empty;
    public string DraftVersion { get; set; } = "1.0";
    public string? StudentDataJson { get; set; }
    public string? StaffDataJson { get; set; }
    public string? FinancialSummaryJson { get; set; }
    public string? AssetSummaryJson { get; set; }
    public decimal CompletenessPercentage { get; set; }
    public int DraftStatus { get; set; } = 1;
    public bool IsLocked { get; set; }
    public DateTime? LockedAt { get; set; }
    public long? LockedByUserId { get; set; }
    public DateTime? LastSavedAt { get; set; }
    public long? SavedByUserId { get; set; }
    public string? Notes { get; set; }
}
