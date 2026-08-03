using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class InventoryItem : BaseAuditableEntity
{
    public long WarehouseId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string? ItemCode { get; set; } // e.g. Textbook ISBN or Asset code
    public int Quantity { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty; // e.g. Box, Piece, Copy
    
    // Navigation Properties
    public virtual Warehouse? Warehouse { get; set; }
    public virtual ICollection<AssetAllocation> Allocations { get; set; } = new List<AssetAllocation>();
}
