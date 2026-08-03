using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetUsageLogs;

public class AssetUsageLogDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int UsageType { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public int DurationMinutes { get; set; }
    public int UsagePurpose { get; set; }
    public string? PurposeDetails { get; set; }
    public long? UsedByUserId { get; set; }
    public int UserType { get; set; }
    public long? LocationId { get; set; }
    public int UsageStatus { get; set; }
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
