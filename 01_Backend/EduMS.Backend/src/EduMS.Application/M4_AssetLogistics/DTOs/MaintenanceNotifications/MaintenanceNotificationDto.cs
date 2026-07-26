using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceNotifications;

public class MaintenanceNotificationDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string RelatedEntityType { get; set; } = string.Empty;
    public long RelatedEntityId { get; set; }
    public int NotificationType { get; set; }
    public string Title { get; set; } = string.Empty;
    public string MessageContent { get; set; } = string.Empty;
    public long RecipientUserId { get; set; }
    public int Priority { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public int DeliveryMethod { get; set; }
    public int NotificationStatus { get; set; } = 1;
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
