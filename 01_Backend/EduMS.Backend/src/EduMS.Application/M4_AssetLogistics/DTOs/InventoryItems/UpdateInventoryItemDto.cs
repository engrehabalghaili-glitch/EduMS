using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.InventoryItems;

public class UpdateInventoryItemDto
{
    public long Id { get; set; }
    public long WarehouseId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string? ItemCode { get; set; }
    public int Quantity { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
}
