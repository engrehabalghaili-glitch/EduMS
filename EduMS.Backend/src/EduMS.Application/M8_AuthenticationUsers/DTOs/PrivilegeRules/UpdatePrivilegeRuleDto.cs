using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.PrivilegeRules;

public class UpdatePrivilegeRuleDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string RuleNameAr { get; set; } = string.Empty;
    public string? RuleNameEn { get; set; }
    public string? RuleCategory { get; set; }
    public string? AppliesToType { get; set; }
    public string? ConditionJson { get; set; }
    public string? TriggerAction { get; set; }
    public string? ActionParametersJson { get; set; }
    public int Priority { get; set; } = 50;
    public bool IsActive { get; set; } = true;
}
