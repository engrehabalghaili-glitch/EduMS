using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.UserGuardianIdentityLinks;

public class UpdateUserGuardianIdentityLinkDto
{
    public long Id { get; set; }
    public long SystemUserId { get; set; }
    public long StudentGuardianRelationshipId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public int LinkStatus { get; set; } = 1;
    public DateTime LinkedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UnlinkedAt { get; set; }
    public string? Notes { get; set; }
}
