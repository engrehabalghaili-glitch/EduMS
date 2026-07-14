using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.UserActivityLogs;

public class UpdateUserActivityLogDto
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
}
