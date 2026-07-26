using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.OfficePermissions;

public class CreateOfficePermissionDto
{
    public long OfficeId { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? ScopeType { get; set; }
    public string? ScopeTargetJson { get; set; }
    public bool CanOverrideSchoolDecision { get; set; }
    public bool IsReadOnly { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
