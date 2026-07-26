using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class AssetAllocation : BaseAuditableEntity
{
    public long InventoryItemId { get; set; }
    public long SchoolId { get; set; }
    public long? ClassroomId { get; set; }
    public long? AssignedToEmployeeId { get; set; }
    public int AllocatedQuantity { get; set; }
    public DateTime AllocationDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Active"; // Active, Returned, Damaged

    // Cross-Module Navigation Properties
    public virtual InventoryItem? InventoryItem { get; set; }
    public virtual School? School { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual Employee? AssignedToEmployee { get; set; }
}
