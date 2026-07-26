using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionBaseModules;

public class PermissionBaseModuleDto
{
    public long Id { get; set; }
    public string ModuleCode { get; set; } = string.Empty;
    public string ModuleNameAr { get; set; } = string.Empty;
    public string? ModuleNameEn { get; set; }
    public string? SectionCode { get; set; }
    public string? SectionNameAr { get; set; }
    public string? SectionNameEn { get; set; }
    public string? Description { get; set; }
    public string? DefaultPermissionsJson { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
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
