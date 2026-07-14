using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionRecords;

public class UpdateBehaviorPermissionRecordDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public long? RoleId { get; set; }
    public string Category { get; set; } = string.Empty;
    public string? SubCategory { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string? AllowedActionsJson { get; set; }
    public string? Scope { get; set; }
    public bool IsSensitive { get; set; }
    public bool RequiresJustification { get; set; }
    public bool JustificationApprovalRequired { get; set; }
    public string? DescriptionAr { get; set; }
    public bool IsActive { get; set; } = true;
}
