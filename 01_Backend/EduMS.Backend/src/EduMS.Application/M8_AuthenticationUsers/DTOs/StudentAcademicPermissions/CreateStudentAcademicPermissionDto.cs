using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.StudentAcademicPermissions;

public class CreateStudentAcademicPermissionDto
{
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; }
    public bool IsTimeBound { get; set; }
    public string? AllowedWindowDays { get; set; }
    public bool RequiresLockOverride { get; set; }
    public bool RequiresSupervisorApproval { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
