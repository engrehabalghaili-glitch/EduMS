using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.StudentFinancePermissions;

public class StudentFinancePermissionDto
{
    public long Id { get; set; }
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
