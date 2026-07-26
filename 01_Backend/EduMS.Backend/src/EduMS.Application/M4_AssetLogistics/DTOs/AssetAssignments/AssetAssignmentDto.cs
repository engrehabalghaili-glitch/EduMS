using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetAssignments;

public class AssetAssignmentDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int AssigneeType { get; set; }
    public long AssigneeId { get; set; }
    public string AssigneeName { get; set; } = string.Empty;
    public long? AssignerUserId { get; set; }
    public DateTime AssignmentDate { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public string? AssignmentReason { get; set; }
    public int ConditionAtAssignment { get; set; }
    public string? ConditionNotesAtAssignment { get; set; }
    public int ConditionAtReturn { get; set; }
    public string? ConditionNotesAtReturn { get; set; }
    public decimal PenaltyAmount { get; set; }
    public int PenaltyStatus { get; set; }
    public int AssignmentStatus { get; set; } = 1;
    public bool IsReturned { get; set; }
    public long? ReturnedToUserId { get; set; }
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
