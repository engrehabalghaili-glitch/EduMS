using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAnnouncementLogs;

public class SchoolAnnouncementLogDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public string AnnouncementContent { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public int TargetAudience { get; set; }
    public bool IsPinned { get; set; }
    public int AnnouncementPriority { get; set; }
    public string? AttachmentFileUrl { get; set; }
    public int ViewCount { get; set; }
    public long? PublishedByEmployeeId { get; set; }
    public bool IsActive { get; set; }

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
