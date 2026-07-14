using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityComparisons;

public class UpdateAssetFeasibilityComparisonDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public DateTime ComparisonDate { get; set; }
    public decimal RepairEstimate { get; set; }
    public string? RepairEstimateBreakdownJson { get; set; }
    public decimal ReplacementCost { get; set; }
    public string? ReplacementCostBreakdownJson { get; set; }
    public string? TcoAnalysisJson { get; set; }
    public int Recommendation { get; set; }
    public string? RecommendationReason { get; set; }
    public int DecisionStatus { get; set; } = 1;
    public DateTime? DecisionDate { get; set; }
    public long? ApprovedByUserId { get; set; }
    public string? Notes { get; set; }
}
