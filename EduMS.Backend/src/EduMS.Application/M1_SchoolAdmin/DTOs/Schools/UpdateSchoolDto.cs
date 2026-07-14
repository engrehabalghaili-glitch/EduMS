using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Schools;

public class UpdateSchoolDto
{
    public long Id { get; set; }
    public long? EducationalStageId { get; set; }
    public string SchoolNameAr { get; set; }
    public string SchoolNameEn { get; set; }
    public string SchoolCode { get; set; }
    public string Directorate { get; set; }
    public string Governorate { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? PostalAddress { get; set; }
    public string? TaxRegistrationNumber { get; set; }
    public string? CommercialLicenseNumber { get; set; }
    public int MaxStudentCapacity { get; set; }
    public bool IsAccredited { get; set; }
}
