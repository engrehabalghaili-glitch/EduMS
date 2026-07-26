using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.SystemPermissions;

public class SystemPermissionDto
{
    public long Id { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
    public string? SubModule { get; set; }
    public string? ActionType { get; set; }
    public long? PermissionTypeId { get; set; }
    public string? DefaultScope { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? RiskLevel { get; set; }
    public bool IsSensitive { get; set; }
    public bool RequiresLogging { get; set; }
    public string? ConditionsJson { get; set; }
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
