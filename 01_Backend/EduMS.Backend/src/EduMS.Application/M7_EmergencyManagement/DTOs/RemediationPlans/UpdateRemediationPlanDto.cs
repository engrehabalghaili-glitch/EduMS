using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.RemediationPlans;

public class UpdateRemediationPlanDto
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
}
