using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.StudentCustodyAssetLinks;

public class StudentCustodyAssetLinkDto
{
    public long Id { get; set; }
    public long StudentInventoryCustodyId { get; set; }
    public long? SchoolAssetId { get; set; }
    public long? InventoryItemId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public decimal ReplacementValue { get; set; }
    public bool IsReturned { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int ConditionOnReturn { get; set; }
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
