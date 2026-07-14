using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.RolePermissions;

public class UpdateRolePermissionDto
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
    public string? ScopeOverride { get; set; }
    public bool IsInherited { get; set; }
    public long? InheritedFromRoleId { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? GrantedByUserId { get; set; }
    public DateTime? GrantedAt { get; set; }
    public string? Notes { get; set; }
}
