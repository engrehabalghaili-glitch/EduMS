using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.UserStudentIdentityLinks;

public class UpdateUserStudentIdentityLinkDto
{
    public long Id { get; set; }
    public long SystemUserId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public int LinkStatus { get; set; } = 1;
    public DateTime LinkedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UnlinkedAt { get; set; }
    public long? LinkedByUserId { get; set; }
    public string? Notes { get; set; }
}
