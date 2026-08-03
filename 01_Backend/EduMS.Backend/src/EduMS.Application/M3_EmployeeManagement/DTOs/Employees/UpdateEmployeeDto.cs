using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.Employees;

public class UpdateEmployeeDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public int WorkLocationType { get; set; } = 3;
    public string EmployeeCode { get; set; } = string.Empty;
    public string NationalIdNumber { get; set; } = string.Empty;
    public int NationalIdType { get; set; }
    public DateTime? NationalIdExpiryDate { get; set; }
    public DateTime? PassportExpiryDate { get; set; }
    public string? ResidenceNumber { get; set; }
    public DateTime? ResidenceExpiryDate { get; set; }
    public string? ResidenceSponsorName { get; set; }
    public string FirstNameAr { get; set; } = string.Empty;
    public string FatherNameAr { get; set; } = string.Empty;
    public string GrandfatherNameAr { get; set; } = string.Empty;
    public string FamilyNameAr { get; set; } = string.Empty;
    public string? FirstNameEn { get; set; }
    public string? FamilyNameEn { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Nationality { get; set; }
    public int MaritalStatus { get; set; }
    public int NumberOfDependents { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public string? BloodType { get; set; }
    public bool HasSpecialNeeds { get; set; }
    public string PhonePrimary { get; set; } = string.Empty;
    public string? PhoneSecondary { get; set; }
    public string? PersonalEmail { get; set; }
    public string OfficialEmail { get; set; } = string.Empty;
    public string? FullAddress { get; set; }
    public string? City { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public int ContractType { get; set; }
    public int EmployeeType { get; set; }
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
    public int EmploymentStatus { get; set; } = 1;
    public bool IsActive { get; set; } = true;
    public bool CanLogin { get; set; }
    public string? PortalUsername { get; set; }
    public string? PortalPasswordHash { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public string? BankName { get; set; }
    public string? BankIban { get; set; }
    public int VerificationStatus { get; set; } = 1;
    public string? Notes { get; set; }
}
