using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.StudentBasePermissions;

public class UpdateStudentBasePermissionDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; }
    public bool RequiresPrincipalApproval { get; set; }
    public bool RequiresGuardianConsent { get; set; }
    public bool IsSensitive { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
