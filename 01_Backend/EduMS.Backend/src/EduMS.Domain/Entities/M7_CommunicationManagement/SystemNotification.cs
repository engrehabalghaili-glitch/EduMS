using EduMS.Domain.Common;
using System;

namespace EduMS.Domain.Entities;

public class SystemNotification : BaseAuditableEntity
{
    public long UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public string? ActionUrl { get; set; }
    public DateTime NotificationDate { get; set; } = DateTime.UtcNow;
}
