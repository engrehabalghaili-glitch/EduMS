using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.GapAnalysisReports;

public class CreateGapAnalysisReportDto
{
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
}
