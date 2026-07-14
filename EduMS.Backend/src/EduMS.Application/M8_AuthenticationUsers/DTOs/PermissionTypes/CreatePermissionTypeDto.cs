using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionTypes;

public class CreatePermissionTypeDto
{
    public string TypeCode { get; set; } = string.Empty;
    public string TypeNameAr { get; set; } = string.Empty;
    public string? TypeNameEn { get; set; }
    public string? Category { get; set; }
    public string? ScopeType { get; set; }
    public string? RiskLevel { get; set; }
    public bool RequiresApproval { get; set; }
    public string? ApprovalLevel { get; set; }
    public string? DescriptionAr { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsSystem { get; set; }
    public int SortOrder { get; set; }
}
