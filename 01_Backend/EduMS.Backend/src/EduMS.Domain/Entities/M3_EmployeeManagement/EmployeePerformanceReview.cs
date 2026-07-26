using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// تقييم أداء الموظفين - Employee performance review extracted from ZIP ERD PerformanceReview table.
/// </summary>
public class EmployeePerformanceReview : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int ReviewPeriodType { get; set; } // 1=Annual, 2=SemiAnnual, 3=Quarterly, 4=Probation
    public DateTime ReviewPeriodStart { get; set; }
    public DateTime ReviewPeriodEnd { get; set; }
    public long ReviewedByEmployeeId { get; set; }
    public DateTime ReviewDate { get; set; }
    public decimal OverallScore { get; set; }
    public string? PerformanceLevel { get; set; } // Excellent, VeryGood, Good, Acceptable, Poor
    public string? KpiScoresJson { get; set; }
    public string? StrengthsText { get; set; }
    public string? AreasForImprovementText { get; set; }
    public string? DevelopmentPlanText { get; set; }
    public string? EmployeeResponseText { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Draft, 2=Submitted, 3=ApprovedByEmployee, 4=Finalized
    public bool IsDisputed { get; set; }
    public string? DisputeReason { get; set; }
    public DateTime? DisputeDate { get; set; }
    public string? FinalDecisionText { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}
