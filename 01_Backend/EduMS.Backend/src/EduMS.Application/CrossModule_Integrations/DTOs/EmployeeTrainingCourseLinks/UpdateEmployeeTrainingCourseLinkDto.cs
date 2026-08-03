using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmployeeTrainingCourseLinks;

public class UpdateEmployeeTrainingCourseLinkDto
{
    public long Id { get; set; }
    public long EmployeeTrainingId { get; set; }
    public long TrainingCourseOfferingId { get; set; }
    public long EmployeeId { get; set; }
    public long SchoolId { get; set; }
    public decimal TrainingFeeAmount { get; set; }
    public string? FundingSource { get; set; }
    public bool CertificateIssued { get; set; }
    public string? CertificateUrl { get; set; }
    public string? Notes { get; set; }
}
