using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityRiskAnalysises;

public class AssetFeasibilityRiskAnalysisDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long? RequirementRequestId { get; set; }
    public string AnalysisNumber { get; set; } = string.Empty;
    public DateTime AnalysisDate { get; set; }
    public long? AnalystEmployeeId { get; set; }
    public string? OperationalRisks { get; set; }
    public string? FinancialRisks { get; set; }
    public int RiskLevel { get; set; }
    public string? RiskMitigationPlan { get; set; }
    public decimal UsefulLifeEstimateYears { get; set; }
    public decimal RoiEstimatePercent { get; set; }
    public decimal NpvEstimate { get; set; }
    public string? AlternativeSolutions { get; set; }
    public int FinalRecommendation { get; set; }
    public string? RecommendationReason { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int AnalysisStatus { get; set; } = 1;
    public string? AttachmentsJson { get; set; }
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
