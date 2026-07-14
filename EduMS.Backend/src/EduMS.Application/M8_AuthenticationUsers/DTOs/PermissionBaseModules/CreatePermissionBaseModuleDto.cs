using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionBaseModules;

public class CreatePermissionBaseModuleDto
{
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
}
