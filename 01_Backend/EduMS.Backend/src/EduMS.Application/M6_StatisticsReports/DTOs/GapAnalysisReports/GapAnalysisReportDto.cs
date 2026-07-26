using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.GapAnalysisReports;

public class GapAnalysisReportDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string AnalysisNumber { get; set; } = string.Empty;
    public string AnalysisType { get; set; } = string.Empty;
    public long? AssetCategoryId { get; set; }
    public long? GradeCapacityId { get; set; }
    public long? DepartmentId { get; set; }
    public int RequiredQuantity { get; set; }
    public int AvailableQuantity { get; set; }
    public decimal GapValue { get; set; }
    public decimal GapPercentage { get; set; }
    public string? GapType { get; set; }
    public string? Recommendation { get; set; }
    public int Priority { get; set; }
    public decimal EstimatedCost { get; set; }
    public DateTime AnalysisDate { get; set; }
    public long? AnalyzedByUserId { get; set; }
    public string? FilePath { get; set; }
    public int AnalysisStatus { get; set; } = 1;
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
