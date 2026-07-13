using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;

public class DirectorateDto
{
    // Base Entity
    public long Id { get; set; }

    // Directorate Properties
    public string DirectorateCode { get; set; } = string.Empty;
    public string DirectorateNameAr { get; set; } = string.Empty;
    public string DirectorateNameEn { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? DirectorName { get; set; }
    public string? Governorate { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public string? RegionCode { get; set; }
    public string? SupervisoryScopeDescription { get; set; }
    public decimal AnnualBudgetLimit { get; set; }
    public int EmployeeCount { get; set; }
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
