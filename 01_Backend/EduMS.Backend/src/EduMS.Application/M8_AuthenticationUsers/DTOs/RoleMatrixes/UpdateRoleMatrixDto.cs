using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.RoleMatrixes;

public class UpdateRoleMatrixDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public string RoleCode { get; set; } = string.Empty;
    public string RoleNameAr { get; set; } = string.Empty;
    public string? RoleNameEn { get; set; }
    public int RoleType { get; set; }
    public string? PermissionsJson { get; set; }
    public string? DescriptionAr { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
}
