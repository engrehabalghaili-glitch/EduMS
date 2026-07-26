using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.RemediationPlans;

public class RemediationPlanDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PlanNumber { get; set; } = string.Empty;
    public string PlanName { get; set; } = string.Empty;
    public long? RelatedDeficitId { get; set; }
    public long? RelatedSurplusId { get; set; }
    public int PlanType { get; set; }
    public string? SelectedOption { get; set; }
    public string? OptionDetails { get; set; }
    public string? Objectives { get; set; }
    public string? ActionStepsJson { get; set; }
    public DateTime? PlannedStartDate { get; set; }
    public DateTime? PlannedEndDate { get; set; }
    public DateTime? ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public decimal EstimatedBudget { get; set; }
    public decimal ActualCost { get; set; }
    public string? Currency { get; set; }
    public long? ExecutionLeadEmployeeId { get; set; }
    public string? ExecutionTeamJson { get; set; }
    public decimal ProgressPercentage { get; set; }
    public int PlanStatus { get; set; } = 1;
    public DateTime? ApprovalDate { get; set; }
    public long? ApprovedByUserId { get; set; }
    public string? CompletionReport { get; set; }
    public string? LessonsLearned { get; set; }
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
