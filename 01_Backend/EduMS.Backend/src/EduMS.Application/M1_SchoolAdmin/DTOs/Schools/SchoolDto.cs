using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Schools;

public class SchoolDto
{
    // Base Entity
    public long Id { get; set; }

    // School Properties
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
    public bool IsActive { get; set; }

    // Auditing Fields (From BaseAuditableEntity)
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    
    // Enum Representation as String
    public string SyncStatus { get; set; } = string.Empty;
}
