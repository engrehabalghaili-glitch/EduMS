using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.Warehouses;

public class WarehouseDto
{
    public long Id { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public string OwnerType { get; set; } = string.Empty;
    public long OwnerId { get; set; }
    public string? LocationAddress { get; set; }
    public bool IsActive { get; set; } = true;
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
