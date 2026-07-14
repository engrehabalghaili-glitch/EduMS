using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.PrivilegeRules;

public class PrivilegeRuleDto
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
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
