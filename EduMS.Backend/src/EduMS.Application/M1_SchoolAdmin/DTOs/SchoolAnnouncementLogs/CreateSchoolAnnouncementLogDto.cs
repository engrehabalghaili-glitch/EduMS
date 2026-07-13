using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAnnouncementLogs;

public class CreateSchoolAnnouncementLogDto
{
    public long SchoolId { get; set; }
    public string TitleAr { get; set; }
    public string TitleEn { get; set; }
    public string AnnouncementContent { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime? ExpireDate { get; set; }
    public int TargetAudience { get; set; }
    public bool IsPinned { get; set; }
    public int AnnouncementPriority { get; set; }
    public string? AttachmentFileUrl { get; set; }
    public int ViewCount { get; set; }
    public long? PublishedByEmployeeId { get; set; }
}
