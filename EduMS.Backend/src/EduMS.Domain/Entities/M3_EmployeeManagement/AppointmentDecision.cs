using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// قرار التعيين الرسمي للموظف - Official appointment decision extracted from ZIP ERD AppointmentDecision table (lines 5464-5496).
/// </summary>
public class AppointmentDecision : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public string DecisionNumber { get; set; } = string.Empty;
    public DateTime DecisionDate { get; set; }
    public int DecisionSource { get; set; } // 1=Ministry, 2=DirectorateOffice, 3=SchoolManagement
    public int DecisionType { get; set; } // 1=NewAppointment, 2=Promotion, 3=Extension, 4=Transfer
    public string JobTitle { get; set; } = string.Empty;
    public string? JobGrade { get; set; }
    public long? DepartmentId { get; set; }
    public int EmploymentType { get; set; } // 1=Permanent, 2=Temporary, 3=Seasonal
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

    public virtual Employee? Employee { get; set; }
}
