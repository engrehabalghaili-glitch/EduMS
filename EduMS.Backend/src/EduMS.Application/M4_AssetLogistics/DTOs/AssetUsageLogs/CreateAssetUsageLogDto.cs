using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetUsageLogs;

public class CreateAssetUsageLogDto
{
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
}
