using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetAllocations;

public class AssetAllocationDto
{
    public long Id { get; set; }
    public long InventoryItemId { get; set; }
    public long SchoolId { get; set; }
    public long? ClassroomId { get; set; }
    public long? AssignedToEmployeeId { get; set; }
    public int AllocatedQuantity { get; set; }
    public DateTime AllocationDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Active";
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
