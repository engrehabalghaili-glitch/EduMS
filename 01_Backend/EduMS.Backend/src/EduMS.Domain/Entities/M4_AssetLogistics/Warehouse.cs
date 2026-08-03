using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Warehouse : BaseAuditableEntity
{
    public string WarehouseName { get; set; } = string.Empty;
    public string OwnerType { get; set; } = string.Empty; // e.g. "Office" or "School"
    public long OwnerId { get; set; } // Reference to OfficeId or SchoolId
    public string? LocationAddress { get; set; }
    public bool IsActive { get; set; } = true;
    
    // Navigation Property
    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
}
