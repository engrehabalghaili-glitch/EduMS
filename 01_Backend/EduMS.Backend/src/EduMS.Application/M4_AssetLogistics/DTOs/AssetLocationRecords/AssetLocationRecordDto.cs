using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetLocationRecords;

public class AssetLocationRecordDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long? ParentLocationId { get; set; }
    public string LocationCode { get; set; } = string.Empty;
    public string LocationNameAr { get; set; } = string.Empty;
    public string? LocationNameEn { get; set; }
    public int LocationType { get; set; }
    public string? BuildingName { get; set; }
    public int? FloorNumber { get; set; }
    public string? RoomNumber { get; set; }
    public bool IsActive { get; set; } = true;
    public long? ResponsiblePersonId { get; set; }
    public string? MapReference { get; set; }
    public string? QrCode { get; set; }
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
