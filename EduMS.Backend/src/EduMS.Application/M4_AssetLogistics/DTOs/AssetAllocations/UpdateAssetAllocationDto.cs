using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetAllocations;

public class UpdateAssetAllocationDto
{
    public long Id { get; set; }
    public long InventoryItemId { get; set; }
    public long SchoolId { get; set; }
    public long? ClassroomId { get; set; }
    public long? AssignedToEmployeeId { get; set; }
    public int AllocatedQuantity { get; set; }
    public DateTime AllocationDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Active";
}
