using EduMS.Domain.Common;
using System;

namespace EduMS.Domain.Entities.M2_StudentAffairs;

public class Registration : BaseAuditableEntity
{
    // Basic Details
    public long ParentId { get; set; }
    public long SchoolId { get; set; }

    public string FirstNameAr { get; set; } = string.Empty;
    public string FatherNameAr { get; set; } = string.Empty;
    public string GrandfatherNameAr { get; set; } = string.Empty;
    public string FamilyNameAr { get; set; } = string.Empty;

    public string FirstNameEn { get; set; } = string.Empty;
    public string FatherNameEn { get; set; } = string.Empty;
    public string GrandfatherNameEn { get; set; } = string.Empty;
    public string FamilyNameEn { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; } = string.Empty;
    public string CountryOfBirth { get; set; } = string.Empty;
    public EduMS.Domain.Enums.Gender Gender { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    // Mother's Details
    public string MotherName { get; set; } = string.Empty;
    public string MotherNationality { get; set; } = string.Empty;
    public string MotherPhone { get; set; } = string.Empty;

    // Documents
    public string? BirthCertificate { get; set; } 
    public string? PersonalPhoto { get; set; }
    public string? IDCardImage { get; set; }

    // Academic Details
    public string? PreviousSchool { get; set; }
    public string? PreviousGrade { get; set; }
    public long RequestedGradeLevelId { get; set; } 
    public long AcademicYearId { get; set; }

    // Additional Info
    public bool HasSpecialNeeds { get; set; }
    public string? SpecialNeedsDetails { get; set; }
    public string? MedicalNotes { get; set; }
    public bool SiblingInSchool { get; set; }
    public string? SiblingNames { get; set; }
    public string? ReferralSource { get; set; }

    // Emergency Contact
    public string EmergencyContactName { get; set; } = string.Empty;
    public string EmergencyContactPhone { get; set; } = string.Empty;
    public string EmergencyContactRelation { get; set; } = string.Empty;

    // Request Status
    public EduMS.Domain.Enums.RegistrationStatus RequestStatus { get; set; } = EduMS.Domain.Enums.RegistrationStatus.Pending; 
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;

    // Review & Approval
    public long? ReviewedByUserId { get; set; }
    public DateTime? ReviewDate { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public long? ConvertedToStudentId { get; set; }

    // Navigation properties
    public Guardian? Parent { get; set; }
    public School? School { get; set; }
    public SystemUser? ReviewedByUser { get; set; }
    public Student? ConvertedToStudent { get; set; }
}
