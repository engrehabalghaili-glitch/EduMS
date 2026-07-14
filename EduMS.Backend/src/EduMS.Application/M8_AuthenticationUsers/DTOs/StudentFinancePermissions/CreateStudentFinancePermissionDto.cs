using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.StudentFinancePermissions;

public class CreateStudentFinancePermissionDto
{
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; }
    public decimal MaxAmountLimit { get; set; }
    public decimal MaxDiscountPercentage { get; set; }
    public bool RequiresDirectorApproval { get; set; }
    public bool RequiresBoardApproval { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}
