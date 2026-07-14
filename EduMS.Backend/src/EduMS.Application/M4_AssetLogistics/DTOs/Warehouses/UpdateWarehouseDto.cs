using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.Warehouses;

public class UpdateWarehouseDto
{
    public long Id { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public string OwnerType { get; set; } = string.Empty;
    public long OwnerId { get; set; }
    public string? LocationAddress { get; set; }
    public bool IsActive { get; set; } = true;
}
