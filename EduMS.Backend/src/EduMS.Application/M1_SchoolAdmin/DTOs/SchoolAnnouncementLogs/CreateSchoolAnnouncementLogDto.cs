using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAnnouncementLogs;

public class CreateSchoolAnnouncementLogDto
{
    public long SchoolId { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public string AnnouncementContent { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExpireDate { get; set; }
    public int TargetAudience { get; set; }
    public bool IsPinned { get; set; } = false;
    public int AnnouncementPriority { get; set; } = 2;
    public string? AttachmentFileUrl { get; set; }
    public int ViewCount { get; set; }
    public long? PublishedByEmployeeId { get; set; }
    public bool IsActive { get; set; } = true;
}
