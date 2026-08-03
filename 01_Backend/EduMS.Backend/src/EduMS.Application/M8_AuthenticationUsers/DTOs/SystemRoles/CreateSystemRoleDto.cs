using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.SystemRoles;

public class CreateSystemRoleDto
{
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
}
