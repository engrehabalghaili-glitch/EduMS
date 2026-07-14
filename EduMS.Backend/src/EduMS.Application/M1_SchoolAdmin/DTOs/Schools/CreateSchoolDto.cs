using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Schools;

public class CreateSchoolDto
{
    public long? DirectorateId { get; set; }
    public long? EducationalStageId { get; set; }
    public string SchoolNameAr { get; set; } = string.Empty;
    public string SchoolNameEn { get; set; } = string.Empty;
    public string SchoolCode { get; set; } = string.Empty;
    public string Directorate { get; set; } = string.Empty;
    public string Governorate { get; set; } = string.Empty;
    public DateTime? EstablishmentDate { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? PostalAddress { get; set; }
    public string? TaxRegistrationNumber { get; set; }
    public string? CommercialLicenseNumber { get; set; }
    public int MaxStudentCapacity { get; set; }
    public bool IsAccredited { get; set; }
    public bool IsActive { get; set; } = true;
}
