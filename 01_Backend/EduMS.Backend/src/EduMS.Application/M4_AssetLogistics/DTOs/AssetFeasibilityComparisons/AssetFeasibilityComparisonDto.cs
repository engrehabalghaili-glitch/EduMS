using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityComparisons;

public class AssetFeasibilityComparisonDto
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
