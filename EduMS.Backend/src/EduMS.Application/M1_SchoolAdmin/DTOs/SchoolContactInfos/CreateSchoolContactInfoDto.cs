using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolContactInfos;

public class CreateSchoolContactInfoDto
{
    public long SchoolId { get; set; }
    public string OfficialPhone { get; set; } = string.Empty;
    public string? Landline { get; set; }
    public string? FaxNumber { get; set; }
    public string OfficialEmail { get; set; } = string.Empty;
    public string? AlternativeEmail { get; set; }
    public string FullAddress { get; set; } = string.Empty;
    public string? StreetName { get; set; }
    public int BuildingNumber { get; set; }
    public string? PostalCode { get; set; }
    public string? DistrictName { get; set; }
    public string? City { get; set; }
    public string? GpsLatitude { get; set; }
    public string? GpsLongitude { get; set; }
    public string? LocationMapUrl { get; set; }
    public string? WorkingHoursJson { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public string? SocialLinksJson { get; set; }
}
