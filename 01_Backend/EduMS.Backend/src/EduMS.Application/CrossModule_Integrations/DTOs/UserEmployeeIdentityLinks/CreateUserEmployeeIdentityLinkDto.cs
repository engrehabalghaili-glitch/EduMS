using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.UserEmployeeIdentityLinks;

public class CreateUserEmployeeIdentityLinkDto
{
    public long SystemUserId { get; set; }
    public long EmployeeId { get; set; }
    public long SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public int LinkStatus { get; set; } = 1;
    public DateTime LinkedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UnlinkedAt { get; set; }
    public string? UnlinkReason { get; set; }
    public long? LinkedByUserId { get; set; }
    public string? Notes { get; set; }
}
