using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomResourceAllocations;

public class ClassroomResourceAllocationDto
{
    public long Id { get; set; }
    public long ClassroomId { get; set; }
    public string ResourceNameAr { get; set; } = string.Empty;
    public string ResourceCode { get; set; } = string.Empty;
    public int ResourceType { get; set; }
    public int Quantity { get; set; }
    public DateTime AssignedDate { get; set; }
    public string? ConditionStatus { get; set; }
    public string? ResourceNameEn { get; set; }
    public string? AssetSerialNumber { get; set; }
    public decimal UnitPurchaseCost { get; set; }
    public DateTime? LastInspectionDate { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }

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
