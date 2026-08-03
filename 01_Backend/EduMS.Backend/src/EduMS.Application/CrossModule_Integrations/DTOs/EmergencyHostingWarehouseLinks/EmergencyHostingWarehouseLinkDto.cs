using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EmergencyHostingWarehouseLinks;

public class EmergencyHostingWarehouseLinkDto
{
    public long Id { get; set; }
    public long EmergencyHostingId { get; set; }
    public long WarehouseId { get; set; }
    public long SchoolId { get; set; }
    public string? SuppliesUsedJson { get; set; }
    public decimal TotalSupplyValue { get; set; }
    public string? Notes { get; set; }
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
