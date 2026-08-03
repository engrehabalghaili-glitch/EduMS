using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// بيانات التواصل والموقع الجغرافي للمدرسة - Extracted from ZIP ERD SchoolContactInfo table (lines 110-138).
/// Separated from School core record for contact details normalization.
/// </summary>
public class SchoolContactInfo : BaseAuditableEntity
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

    // Navigation Property
    public virtual School? School { get; set; }
}
