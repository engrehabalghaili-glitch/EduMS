using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePerformanceReviews;

public class CreateEmployeePerformanceReviewDto
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int ReviewPeriodType { get; set; }
    public DateTime ReviewPeriodStart { get; set; }
    public DateTime ReviewPeriodEnd { get; set; }
    public long ReviewedByEmployeeId { get; set; }
    public DateTime ReviewDate { get; set; }
    public decimal OverallScore { get; set; }
    public string? PerformanceLevel { get; set; }
    public string? KpiScoresJson { get; set; }
    public string? StrengthsText { get; set; }
    public string? AreasForImprovementText { get; set; }
    public string? DevelopmentPlanText { get; set; }
    public string? EmployeeResponseText { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public bool IsDisputed { get; set; }
    public string? DisputeReason { get; set; }
    public DateTime? DisputeDate { get; set; }
    public string? FinalDecisionText { get; set; }
    public string? Notes { get; set; }
}
