using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.UserStudentIdentityLinks;

public class UserStudentIdentityLinkDto
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
