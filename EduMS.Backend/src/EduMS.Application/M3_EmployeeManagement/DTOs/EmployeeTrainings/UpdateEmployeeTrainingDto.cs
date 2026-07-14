using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTrainings;

public class UpdateEmployeeTrainingDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public string? CourseCode { get; set; }
    public int TrainingType { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DurationHours { get; set; }
    public string? TrainingLocation { get; set; }
    public decimal TrainingCost { get; set; }
    public string? FundingSource { get; set; }
    public int CompletionStatus { get; set; } = 1;
    public decimal? Score { get; set; }
    public string? GradeLevel { get; set; }
    public string? CertificateUrl { get; set; }
    public DateTime? CertificateExpiryDate { get; set; }
    public string? TrainingOutcomesSummary { get; set; }
    public string? Notes { get; set; }
}
