using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.AccessPolicies;

public class CreateAccessPolicyDto
{
    public long? SchoolId { get; set; }
    public string PolicyCode { get; set; } = string.Empty;
    public string PolicyNameAr { get; set; } = string.Empty;
    public string? PolicyNameEn { get; set; }
    public int PolicyType { get; set; }
    public string? PolicyRuleJson { get; set; }
    public int PolicyEffect { get; set; }
    public int Priority { get; set; } = 50;
    public string? AppliesToType { get; set; }
    public string? AppliesToIdsJson { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}
