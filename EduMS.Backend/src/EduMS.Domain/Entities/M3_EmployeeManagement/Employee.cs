using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الموظف - Core employee record. Inherits personal identity from the TPT Person hierarchy.
/// Extends with job-specific, payroll, authentication, and credential fields from M3 ERD.
/// Source: faild_053908.txt Employee table lines 5353-5462.
/// </summary>
public class Employee : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string EmployeeCode { get; set; } = string.Empty;
    public string NationalIdNumber { get; set; } = string.Empty;
    public int NationalIdType { get; set; } // 1=Saudi, 2=Resident, 3=GCC, 4=Visitor
    public DateTime? NationalIdExpiryDate { get; set; }
    public string? PassportNumber { get; set; }
    public DateTime? PassportExpiryDate { get; set; }
    public string? ResidenceNumber { get; set; }
    public DateTime? ResidenceExpiryDate { get; set; }
    public string? ResidenceSponsorName { get; set; }

    // Name fields (no duplication with Person — Person is not yet wired; standalone for M3)
    public string FirstNameAr { get; set; } = string.Empty;
    public string FatherNameAr { get; set; } = string.Empty;
    public string GrandfatherNameAr { get; set; } = string.Empty;
    public string FamilyNameAr { get; set; } = string.Empty;
    public string FullNameAr { get; set; } = string.Empty;
    public string? FirstNameEn { get; set; }
    public string? FamilyNameEn { get; set; }
    public string? FullNameEn { get; set; }
    public string Gender { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string? Nationality { get; set; }
    public int MaritalStatus { get; set; } // 1=Single, 2=Married, 3=Divorced, 4=Widowed
    public int NumberOfDependents { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public string? BloodType { get; set; }
    public bool HasSpecialNeeds { get; set; }

    // Contact
    public string PhonePrimary { get; set; } = string.Empty;
    public string? PhoneSecondary { get; set; }
    public string? PersonalEmail { get; set; }
    public string OfficialEmail { get; set; } = string.Empty;
    public string? FullAddress { get; set; }
    public string? City { get; set; }
    public string? ProfilePhotoUrl { get; set; }

    // Employment
    public int ContractType { get; set; } // 1=Permanent, 2=Temporary, 3=Seasonal, 4=Probation
    public int EmployeeType { get; set; } // 1=Teacher, 2=Admin, 3=Technical, 4=Supervisor, 5=Director
    public long? DepartmentId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string? JobGrade { get; set; }
    public string? Specialization { get; set; }
    public string? AcademicQualification { get; set; }
    public string? QualificationSource { get; set; }
    public int ExperienceYears { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int EmploymentStatus { get; set; } = 1; // 1=Active, 2=Seconded, 3=Delegated, 4=OnLeave, 5=Terminated
    public bool IsActive { get; set; } = true;

    // Portal Access
    public bool CanLogin { get; set; }
    public string? PortalUsername { get; set; }
    public string? PortalPasswordHash { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public bool TwoFactorEnabled { get; set; }

    // Bank Details
    public string? BankName { get; set; }
    public string? BankIban { get; set; }

    // Verification
    public int VerificationStatus { get; set; } = 1; // 1=Pending, 2=Verified, 3=Rejected
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Department? Department { get; set; }
}
