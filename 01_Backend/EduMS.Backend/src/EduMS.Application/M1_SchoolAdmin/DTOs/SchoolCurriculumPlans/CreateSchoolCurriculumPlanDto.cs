using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCurriculumPlans;

public class CreateSchoolCurriculumPlanDto
{
    public long SchoolId { get; set; }
    public string PlanNameAr { get; set; }
    public string? PlanNameEn { get; set; }
    public string PlanCode { get; set; }
    public long? GradeCapacityId { get; set; }
    public long? SchoolLevelId { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string PlanVersion { get; set; }
    public DateTime AdoptionDate { get; set; }
    public decimal TotalCreditHours { get; set; }
    public string? ApprovalDocumentUrl { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Notes { get; set; }
}
