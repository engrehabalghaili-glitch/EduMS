using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.GovernanceRbacRules;

public class UpdateGovernanceRbacRuleDto
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public long? TargetRoleId { get; set; }
    public long? TargetPermissionId { get; set; }
    public string AllowedAction { get; set; } = string.Empty;
    public bool CanDelegate { get; set; }
    public bool ApprovalRequired { get; set; }
    public long? ApprovalRoleId { get; set; }
    public string? Notes { get; set; }
}
