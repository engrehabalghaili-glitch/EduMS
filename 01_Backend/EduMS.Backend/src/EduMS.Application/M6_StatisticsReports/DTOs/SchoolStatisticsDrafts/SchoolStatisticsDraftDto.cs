using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.SchoolStatisticsDrafts;

public class SchoolStatisticsDraftDto
{
    public long Id { get; set; }
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
