using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmergencyIncidentAssetImpacts;

public class UpdateEmergencyIncidentAssetImpactDto
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
}
