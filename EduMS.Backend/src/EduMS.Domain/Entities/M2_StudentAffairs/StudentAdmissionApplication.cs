using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// طلب التسجيل والقبول المدرسي - Student admission application extracted from ZIP ERD Application table (lines 1639-1691).
/// Pre-enrollment workflow: the application is submitted by the guardian and, upon approval, converted to a Student record.
/// Does NOT duplicate personal data stored in Person/Student — only admission-process fields are stored here.
/// </summary>
public class StudentAdmissionApplication : BaseAuditableEntity
{
    public long GuardianId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string RequestedGradeLevelCode { get; set; } = string.Empty;
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    public int RequestStatus { get; set; } = 1; // 1=Pending, 2=Accepted, 3=Rejected, 4=Incomplete
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
    public long? ConvertedToStudentId { get; set; }   // FK populated after acceptance

    // Navigation Properties
    public virtual Guardian? Guardian { get; set; }
    public virtual School? School { get; set; }
}
