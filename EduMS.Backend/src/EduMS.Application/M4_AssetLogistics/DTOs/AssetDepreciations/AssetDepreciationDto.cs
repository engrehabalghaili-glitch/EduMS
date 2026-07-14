using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetDepreciations;

public class AssetDepreciationDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int MethodType { get; set; }
    public int UsefulLifeYears { get; set; }
    public decimal DepreciationRate { get; set; }
    public decimal CurrentBookValue { get; set; }
    public decimal AccumulatedDepreciation { get; set; }
    public decimal NetBookValue { get; set; }
    public decimal DepreciableAmount { get; set; }
    public DateTime? LastDepreciationDate { get; set; }
    public string? LastDepreciationPeriod { get; set; }
    public bool IsFullyDepreciated { get; set; }
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
