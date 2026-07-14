using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.AppointmentDecisions;

public class UpdateAppointmentDecisionDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public string DecisionNumber { get; set; } = string.Empty;
    public DateTime DecisionDate { get; set; }
    public int DecisionSource { get; set; }
    public int DecisionType { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string? JobGrade { get; set; }
    public long? DepartmentId { get; set; }
    public int EmploymentType { get; set; }
    public DateTime StartDate { get; set; }
    public int ProbationPeriodMonths { get; set; }
    public DateTime? ProbationEndDate { get; set; }
    public decimal SalaryAmount { get; set; }
    public string? AllowanceDetailsJson { get; set; }
    public string? OtherBenefits { get; set; }
    public string? AttachmentUrl { get; set; }
    public string? ApprovedByName { get; set; }
    public string? ApprovedByTitle { get; set; }
    public string? Notes { get; set; }
}
