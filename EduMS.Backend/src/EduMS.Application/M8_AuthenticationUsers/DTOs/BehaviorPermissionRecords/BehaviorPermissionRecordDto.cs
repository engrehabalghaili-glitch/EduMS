using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionRecords;

public class BehaviorPermissionRecordDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public long? RoleId { get; set; }
    public string Category { get; set; } = string.Empty;
    public string? SubCategory { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string? AllowedActionsJson { get; set; }
    public string? Scope { get; set; }
    public bool IsSensitive { get; set; }
    public bool RequiresJustification { get; set; }
    public bool JustificationApprovalRequired { get; set; }
    public string? DescriptionAr { get; set; }
    public bool IsActive { get; set; } = true;
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
