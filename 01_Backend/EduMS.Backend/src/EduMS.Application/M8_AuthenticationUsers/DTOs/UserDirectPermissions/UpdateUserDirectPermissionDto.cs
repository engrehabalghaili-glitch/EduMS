using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.UserDirectPermissions;

public class UpdateUserDirectPermissionDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long PermissionId { get; set; }
    public long? SchoolId { get; set; }
    public string? ScopeOverride { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? GrantedByUserId { get; set; }
    public DateTime? GrantedAt { get; set; }
    public string? Reason { get; set; }
    public string? Notes { get; set; }
}
