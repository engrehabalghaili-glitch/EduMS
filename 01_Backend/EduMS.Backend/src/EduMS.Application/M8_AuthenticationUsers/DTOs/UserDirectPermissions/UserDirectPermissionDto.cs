using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.UserDirectPermissions;

public class UserDirectPermissionDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long PermissionId { get; set; }
    public long? SchoolId { get; set; }
    public string? ScopeOverride { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? GrantedByUserId { get; set; }
    public DateTime? GrantedAt { get; set; }
    public string? Reason { get; set; }
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
