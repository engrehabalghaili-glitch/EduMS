using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateStatisticalReports;

public class DirectorateStatisticalReportDto
{
    public long Id { get; set; }
    public long DirectorateId { get; set; }
    public string ReportCode { get; set; } = string.Empty;
    public string ReportTitleAr { get; set; } = string.Empty;
    public string? ReportTitleEn { get; set; }
    public int TargetCategory { get; set; }
    public int PeriodType { get; set; }
    public string TargetAcademicYear { get; set; } = string.Empty;
    public string StatisticalDataPayloadJson { get; set; } = string.Empty;
    public string? AnalyticalSummary { get; set; }
    public string? RecommendationsText { get; set; }
    public DateTime GenerationDate { get; set; }
    public long? CompiledByEmployeeId { get; set; }
    public int VerificationStatus { get; set; }

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
