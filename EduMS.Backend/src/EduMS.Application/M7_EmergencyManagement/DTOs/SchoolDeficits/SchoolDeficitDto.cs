using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.SchoolDeficits;

public class SchoolDeficitDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string DeficitNumber { get; set; } = string.Empty;
    public string DeficitType { get; set; } = string.Empty;
    public string? DeficitCategory { get; set; }
    public decimal DeficitAmount { get; set; }
    public decimal RequiredAmount { get; set; }
    public decimal AvailableAmount { get; set; }
    public string? DeficitDescription { get; set; }
    public string? EducationalImpact { get; set; }
    public int ImpactLevel { get; set; }
    public DateTime DetectionDate { get; set; }
    public long? DetectedByUserId { get; set; }
    public int DeficitStatus { get; set; } = 1;
    public DateTime? StatusUpdateDate { get; set; }
    public string? ProposedSolution { get; set; }
    public decimal EstimatedResolutionCost { get; set; }
    public DateTime? EstimatedResolutionDate { get; set; }
    public DateTime? ActualResolutionDate { get; set; }
    public long? ResolvedByUserId { get; set; }
    public string? ResolutionNotes { get; set; }
    public long? RelatedRemediationPlanId { get; set; }
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
