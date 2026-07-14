using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionTypes;

public class PermissionTypeDto
{
    public long Id { get; set; }
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
