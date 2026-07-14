using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmployeeTrainingCourseLinks;

public class EmployeeTrainingCourseLinkDto
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
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
