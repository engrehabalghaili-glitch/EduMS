using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.AccessPolicies;

public class AccessPolicyDto
{
    public long Id { get; set; }
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
