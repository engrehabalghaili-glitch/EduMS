using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilities;

public class SchoolFacilityDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string FacilityCode { get; set; } = string.Empty;
    public string FacilityNameAr { get; set; } = string.Empty;
    public string FacilityNameEn { get; set; } = string.Empty;
    public int FacilityType { get; set; }
    public int Capacity { get; set; }
    public long? AssignedSupervisorId { get; set; }
    public bool IsOperational { get; set; }
    public string? LocationFloor { get; set; }
    public string? BuildingName { get; set; }
    public DateTime? SafetyInspectionDate { get; set; }
    public int MaintenanceStatus { get; set; }

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
