using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.JobApplicants;

public class UpdateJobApplicantDto
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
}
