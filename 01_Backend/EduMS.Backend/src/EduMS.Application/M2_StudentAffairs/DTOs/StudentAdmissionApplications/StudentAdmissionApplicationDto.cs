using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAdmissionApplications;

public class StudentAdmissionApplicationDto
{
    public long Id { get; set; }
    public long GuardianId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string RequestedGradeLevelCode { get; set; } = string.Empty;
    public DateTime SubmissionDate { get; set; }
    public int RequestStatus { get; set; }
    public string? BirthCertificateAttachmentUrl { get; set; }
    public string? PersonalPhotoAttachmentUrl { get; set; }
    public string? PreviousSchoolName { get; set; }
    public string? PreviousSchoolGradeLevel { get; set; }
    public bool HasSpecialNeeds { get; set; }
    public string? SpecialNeedsDetails { get; set; }
    public string? MedicalNotes { get; set; }
    public bool HasSiblingInSchool { get; set; }
    public string? SiblingNames { get; set; }
    public string? ReferralSource { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public long? ReviewedByEmployeeId { get; set; }
    public DateTime? ReviewDate { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public long? ConvertedToStudentId { get; set; }

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
