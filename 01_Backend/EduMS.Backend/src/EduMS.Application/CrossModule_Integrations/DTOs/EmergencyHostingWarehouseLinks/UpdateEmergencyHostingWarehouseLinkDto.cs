using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmergencyHostingWarehouseLinks;

public class UpdateEmergencyHostingWarehouseLinkDto
{
    public long Id { get; set; }
    public long EmergencyHostingId { get; set; }
    public long WarehouseId { get; set; }
    public long SchoolId { get; set; }
    public string? SuppliesUsedJson { get; set; }
    public decimal TotalSupplyValue { get; set; }
    public string? Notes { get; set; }
}
