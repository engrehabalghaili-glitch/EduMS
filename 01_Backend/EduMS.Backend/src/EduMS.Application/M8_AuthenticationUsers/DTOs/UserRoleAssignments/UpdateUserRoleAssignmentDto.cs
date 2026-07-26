using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.UserRoleAssignments;

public class UpdateUserRoleAssignmentDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public long? SchoolId { get; set; }
    public bool IsPrimary { get; set; }
    public string? ScopeContextJson { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public long? AssignedByUserId { get; set; }
    public DateTime? AssignedAt { get; set; }
    public string? Notes { get; set; }
}
