using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionMatrixes;

public class BehaviorPermissionMatrixDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long RoleId { get; set; }
    public string BehaviorLevel { get; set; } = string.Empty;
    public bool CanRecord { get; set; }
    public bool CanInvestigate { get; set; }
    public bool CanDecidePenalty { get; set; }
    public bool CanExecutePenalty { get; set; }
    public bool CanWaivePenalty { get; set; }
    public bool RequiresCommitteeDecision { get; set; }
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
