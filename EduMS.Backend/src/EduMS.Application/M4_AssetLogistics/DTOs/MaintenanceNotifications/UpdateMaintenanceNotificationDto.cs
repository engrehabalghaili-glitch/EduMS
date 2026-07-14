using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceNotifications;

public class UpdateMaintenanceNotificationDto
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
}
