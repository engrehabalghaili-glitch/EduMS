using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.FieldInventoryLogs;

public class CreateFieldInventoryLogDto
{
    public long InventoryPlanId { get; set; }
    public long SchoolId { get; set; }
    public long ScannerUserId { get; set; }
    public DateTime ScanTimestamp { get; set; }
    public string ScannedCode { get; set; } = string.Empty;
    public long? AssetId { get; set; }
    public string? PhysicalLocationText { get; set; }
    public int ActualCondition { get; set; }
    public string? ConditionNotes { get; set; }
    public bool IsFound { get; set; } = true;
    public string? NotFoundNotes { get; set; }
    public string? AssetPhotoUrl { get; set; }
    public string? GpsLocation { get; set; }
    public bool IsVerified { get; set; }
    public long? VerifiedByUserId { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? Notes { get; set; }
}
