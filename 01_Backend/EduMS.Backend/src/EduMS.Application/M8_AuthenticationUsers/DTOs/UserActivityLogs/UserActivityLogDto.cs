using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.UserActivityLogs;

public class UserActivityLogDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long? SchoolId { get; set; }
    public string ActivityType { get; set; } = string.Empty;
    public DateTime ActivityTimestamp { get; set; } = DateTime.UtcNow;
    public int ActivityStatus { get; set; }
    public string? FailureReason { get; set; }
    public string? IpAddress { get; set; }
    public string? DeviceType { get; set; }
    public string? DeviceName { get; set; }
    public string? OperatingSystem { get; set; }
    public string? Browser { get; set; }
    public string? UserAgent { get; set; }
    public string? LocationText { get; set; }
    public string? SessionId { get; set; }
    public string? ActionDetailsJson { get; set; }
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
