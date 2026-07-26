using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.TrendAnalysisResults;

public class UpdateTrendAnalysisResultDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string StudyPeriod { get; set; } = string.Empty;
    public string StartYear { get; set; } = string.Empty;
    public string EndYear { get; set; } = string.Empty;
    public string KpiCode { get; set; } = string.Empty;
    public string? HistoricalValuesJson { get; set; }
    public string? TrendDirection { get; set; }
    public decimal? Slope { get; set; }
    public decimal? CorrelationCoefficient { get; set; }
    public decimal? ForecastedValueNext1Year { get; set; }
    public decimal? ForecastedValueNext2Year { get; set; }
    public decimal? ConfidenceLevel { get; set; }
    public decimal? LowerBound { get; set; }
    public decimal? UpperBound { get; set; }
    public string? ForecastingMethod { get; set; }
    public DateTime AnalysisDate { get; set; }
    public long? AnalyzedByUserId { get; set; }
    public int AnalysisStatus { get; set; } = 1;
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Notes { get; set; }
}
