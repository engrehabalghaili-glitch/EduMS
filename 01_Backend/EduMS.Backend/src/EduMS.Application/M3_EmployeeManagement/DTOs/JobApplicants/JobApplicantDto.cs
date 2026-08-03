using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.JobApplicants;

public class JobApplicantDto
{
    public long Id { get; set; }
    public long VacantPositionId { get; set; }
    public string ApplicantFullNameAr { get; set; } = string.Empty;
    public string? ApplicantFullNameEn { get; set; }
    public string NationalIdNumber { get; set; } = string.Empty;
    public string PhonePrimary { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string AcademicQualification { get; set; } = string.Empty;
    public string? QualificationSource { get; set; }
    public int ExperienceYears { get; set; }
    public string? CvDocumentUrl { get; set; }
    public string? CoverLetterUrl { get; set; }
    public int ApplicationStatus { get; set; } = 1;
    public DateTime? InterviewDate { get; set; }
    public string? InterviewNotes { get; set; }
    public string? RejectionReason { get; set; }
    public long? ReviewedByEmployeeId { get; set; }
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
