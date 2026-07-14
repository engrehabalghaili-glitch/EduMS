using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.Warehouses;

public class CreateWarehouseDto
{
    public string WarehouseName { get; set; } = string.Empty;
    public string OwnerType { get; set; } = string.Empty;
    public long OwnerId { get; set; }
    public string? LocationAddress { get; set; }
    public bool IsActive { get; set; } = true;
}
