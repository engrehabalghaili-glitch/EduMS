using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmergencyIncidentAssetImpacts;

public class EmergencyIncidentAssetImpactDto
{
    public long Id { get; set; }
    public long EmergencyIncidentId { get; set; }
    public long SchoolAssetId { get; set; }
    public long SchoolId { get; set; }
    public int ImpactType { get; set; }
    public decimal EstimatedDamageValue { get; set; }
    public string? DamageDescription { get; set; }
    public bool RequiresMaintenance { get; set; }
    public long? MaintenanceTicketId { get; set; }
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
