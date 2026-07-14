using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.EducationalSupervisionVisits;

public class CreateEducationalSupervisionVisitDto
{
    public long DirectorateId { get; set; }
    public long SchoolId { get; set; }
    public string SupervisorName { get; set; }
    public DateTime VisitDate { get; set; }
    public string VisitPurpose { get; set; }
    public decimal? EvaluationScore { get; set; }
    public string? Recommendations { get; set; }
    public long? SupervisorEmployeeId { get; set; }
    public long? TargetDepartmentId { get; set; }
    public DateTime? FollowUpRequiredDate { get; set; }
    public string? ActionItemsDetail { get; set; }
}
