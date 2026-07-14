using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCurriculumPlans;

public class UpdateSchoolCurriculumPlanDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PlanNameAr { get; set; } = string.Empty;
    public string? PlanNameEn { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public long? GradeCapacityId { get; set; }
    public long? SchoolLevelId { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string PlanVersion { get; set; } = string.Empty;
    public DateTime AdoptionDate { get; set; }
    public decimal TotalCreditHours { get; set; }
    public int PlanStatus { get; set; }
    public int MinisterialApprovalStatus { get; set; }
    public string? ApprovalDocumentUrl { get; set; }
    public bool IsActive { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Notes { get; set; }
}
