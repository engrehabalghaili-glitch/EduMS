using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolAnnouncementLog : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public string AnnouncementContent { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExpireDate { get; set; }
    public int TargetAudience { get; set; } // 1=Students, 2=Guardians, 3=Teachers, 4=All
    public bool IsPinned { get; set; } = false;
    public int AnnouncementPriority { get; set; } = 2; // 1=Low, 2=Normal, 3=High, 4=Urgent
    public string? AttachmentFileUrl { get; set; }
    public int ViewCount { get; set; }
    public long? PublishedByEmployeeId { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public virtual School? School { get; set; }
    public virtual Employee? PublishedByEmployee { get; set; }
}
