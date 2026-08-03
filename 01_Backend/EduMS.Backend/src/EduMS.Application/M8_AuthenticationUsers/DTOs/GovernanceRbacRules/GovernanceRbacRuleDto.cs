using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.GovernanceRbacRules;

public class GovernanceRbacRuleDto
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public long? TargetRoleId { get; set; }
    public long? TargetPermissionId { get; set; }
    public string AllowedAction { get; set; } = string.Empty;
    public bool CanDelegate { get; set; }
    public bool ApprovalRequired { get; set; }
    public long? ApprovalRoleId { get; set; }
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
