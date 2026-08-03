using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.OrganizationalSectors;

public class OrganizationalSectorDto
{
    public long Id { get; set; }
    public string SectorCode { get; set; } = string.Empty;
    public string SectorNameAr { get; set; } = string.Empty;
    public string? SectorNameEn { get; set; }
    public int SectorType { get; set; } = 3;
    public long? ParentSectorId { get; set; }
    public long? DirectorateId { get; set; }
    public long? SchoolId { get; set; }
    public string? CostCenterCode { get; set; }
    public decimal AnnualHrBudget { get; set; }
    public long? HeadOfSectorEmployeeId { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
