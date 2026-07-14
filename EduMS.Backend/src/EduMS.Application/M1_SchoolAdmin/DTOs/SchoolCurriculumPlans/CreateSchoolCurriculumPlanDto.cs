using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCurriculumPlans;

public class CreateSchoolCurriculumPlanDto
{
    public long SchoolId { get; set; }
    public string PlanNameAr { get; set; } = string.Empty;
    public string? PlanNameEn { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public long? GradeCapacityId { get; set; }
    public long? SchoolLevelId { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string PlanVersion { get; set; } = "V1.0";
    public DateTime AdoptionDate { get; set; }
    public decimal TotalCreditHours { get; set; }
    public int PlanStatus { get; set; } = 1;
    public int MinisterialApprovalStatus { get; set; } = 1;
    public string? ApprovalDocumentUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Notes { get; set; }
}
