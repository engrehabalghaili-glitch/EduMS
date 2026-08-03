using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetMovementHistories;

public class CreateAssetMovementHistoryDto
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public string ActionDescription { get; set; } = string.Empty;
    public string? OldValueJson { get; set; }
    public string? NewValueJson { get; set; }
    public string? RelatedEntityType { get; set; }
    public long? RelatedEntityId { get; set; }
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;
    public long PerformedByUserId { get; set; }
    public string? Notes { get; set; }
}
