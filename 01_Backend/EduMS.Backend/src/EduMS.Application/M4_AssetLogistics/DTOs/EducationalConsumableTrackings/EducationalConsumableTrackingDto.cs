using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.EducationalConsumableTrackings;

public class EducationalConsumableTrackingDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ConsumableName { get; set; } = string.Empty;
    public string? ConsumableCode { get; set; }
    public string? Category { get; set; }
    public int QuantityConsumed { get; set; }
    public string UnitOfMeasure { get; set; } = string.Empty;
    public DateTime ConsumptionDate { get; set; }
    public long? ConsumedByUserId { get; set; }
    public long? DepartmentId { get; set; }
    public long? SubjectId { get; set; }
    public string? Purpose { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TotalCost { get; set; }
    public string? BudgetLineCode { get; set; }
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
