using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الوظائف الشاغرة وطلبات التوظيف - Vacant positions and job applicants extracted from ZIP ERD VacantPosition and JobApplicant tables.
/// </summary>
public class VacantPosition : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string PositionCode { get; set; } = string.Empty;
    public string PositionTitleAr { get; set; } = string.Empty;
    public string? PositionTitleEn { get; set; }
    public long? DepartmentId { get; set; }
    public int EmployeeType { get; set; } // 1=Teacher, 2=Admin, 3=Technical
    public string? RequiredQualification { get; set; }
    public int ExperienceRequiredYears { get; set; }
    public decimal SalaryRangeMin { get; set; }
    public decimal SalaryRangeMax { get; set; }
    public int VacancyStatus { get; set; } = 1; // 1=Open, 2=Filled, 3=OnHold, 4=Cancelled
    public DateTime PostingDate { get; set; } = DateTime.UtcNow;
    public DateTime? ClosingDate { get; set; }
    public string? SpecialRequirements { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}

/// <summary>
/// طلب التوظيف المقدم للوظيفة الشاغرة - extracted from ZIP ERD JobApplicant table.
/// </summary>
public class JobApplicant : BaseAuditableEntity
{
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
    public int ApplicationStatus { get; set; } = 1; // 1=Submitted, 2=Shortlisted, 3=Interviewed, 4=Accepted, 5=Rejected
    public DateTime? InterviewDate { get; set; }
    public string? InterviewNotes { get; set; }
    public string? RejectionReason { get; set; }
    public long? ReviewedByEmployeeId { get; set; }
    public string? Notes { get; set; }

    public virtual VacantPosition? VacantPosition { get; set; }
}
