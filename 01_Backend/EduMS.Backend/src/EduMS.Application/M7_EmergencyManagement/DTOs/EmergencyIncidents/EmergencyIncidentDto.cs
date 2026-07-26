using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyIncidents;

public class EmergencyIncidentDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string IncidentNumber { get; set; } = string.Empty;
    public string IncidentType { get; set; } = string.Empty;
    public DateTime IncidentDate { get; set; }
    public DateTime? IncidentTime { get; set; }
    public int Severity { get; set; }
    public string? Description { get; set; }
    public string? LocationText { get; set; }
    public long? ReportedByUserId { get; set; }
    public DateTime? ReportedAt { get; set; }
    public bool IsPlanActive { get; set; }
    public long? EmergencyPlanId { get; set; }
    public int AffectedCount { get; set; }
    public int StudentsAffected { get; set; }
    public int EmployeesAffected { get; set; }
    public int InjuriesCount { get; set; }
    public int SevereInjuriesCount { get; set; }
    public int FatalitiesCount { get; set; }
    public decimal PropertyDamage { get; set; }
    public string? PropertyDamageDescription { get; set; }
    public string? EmergencyResponseActions { get; set; }
    public string? ExternalAgenciesJson { get; set; }
    public DateTime? ExternalResponseTime { get; set; }
    public int IncidentStatus { get; set; } = 1;
    public DateTime? ClosureDate { get; set; }
    public string? ClosureNotes { get; set; }
    public string? InvestigationReportUrl { get; set; }
    public string? LessonsLearned { get; set; }
    public string? Recommendations { get; set; }
    public string? AttachmentsJson { get; set; }
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
