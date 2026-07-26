using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// تدريب الموظفين والدورات - Employee training records extracted from ZIP ERD EmployeeTraining table.
/// </summary>
public class EmployeeTraining : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string? CourseCode { get; set; }
    public int TrainingType { get; set; } // 1=Internal, 2=External, 3=Online, 4=Conference
    public string ProviderName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DurationHours { get; set; }
    public string? TrainingLocation { get; set; }
    public decimal TrainingCost { get; set; }
    public string? FundingSource { get; set; }
    public int CompletionStatus { get; set; } = 1; // 1=Registered, 2=InProgress, 3=Completed, 4=Cancelled
    public decimal? Score { get; set; }
    public string? GradeLevel { get; set; } // Pass, Fail, Excellent
    public string? CertificateUrl { get; set; }
    public DateTime? CertificateExpiryDate { get; set; }
    public string? TrainingOutcomesSummary { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}
