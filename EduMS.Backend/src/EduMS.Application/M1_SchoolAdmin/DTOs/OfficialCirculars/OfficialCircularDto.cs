using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.OfficialCirculars;

public class OfficialCircularDto
{
    public long Id { get; set; }
    public string CircularNumber { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public int CircularType { get; set; }
    public string IssuerName { get; set; } = string.Empty;
    public int TargetAudience { get; set; }
    public DateTime EffectiveDate { get; set; }
    public bool IsActive { get; set; }
    public string? ContentBody { get; set; }
    public long? IssuerEmployeeId { get; set; }
    public string? AttachmentFileUrl { get; set; }
    public bool RequiresMandatoryAcknowledgment { get; set; }
    public DateTime? AcknowledgmentDeadline { get; set; }

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
