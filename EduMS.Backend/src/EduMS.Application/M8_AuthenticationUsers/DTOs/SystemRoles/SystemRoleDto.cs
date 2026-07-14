using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.SystemRoles;

public class SystemRoleDto
{
    public long Id { get; set; }
    public string RoleCode { get; set; } = string.Empty;
    public string RoleNameAr { get; set; } = string.Empty;
    public string? RoleNameEn { get; set; }
    public int RoleType { get; set; }
    public int HierarchyLevel { get; set; } = 1;
    public long? ParentRoleId { get; set; }
    public bool IsInheritable { get; set; }
    public bool IsAssignable { get; set; } = true;
    public bool IsSystem { get; set; }
    public bool IsActive { get; set; } = true;
    public string? DescriptionAr { get; set; }
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
