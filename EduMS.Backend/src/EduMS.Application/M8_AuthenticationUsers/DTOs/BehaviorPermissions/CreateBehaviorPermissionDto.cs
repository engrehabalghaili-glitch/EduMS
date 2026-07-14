using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissions;

public class CreateBehaviorPermissionDto
{
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; }
    public bool IsConfidential { get; set; }
    public bool RequiresSocialWorkerRole { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
