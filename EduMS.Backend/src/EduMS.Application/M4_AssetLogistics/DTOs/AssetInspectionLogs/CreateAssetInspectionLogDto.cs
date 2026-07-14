using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetInspectionLogs;

public class CreateAssetInspectionLogDto
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public string RelatedTransactionType { get; set; } = string.Empty;
    public long? RelatedTransactionId { get; set; }
    public int InspectionType { get; set; }
    public DateTime InspectionDate { get; set; }
    public long InspectorUserId { get; set; }
    public int PhysicalCondition { get; set; }
    public string? DamageDetails { get; set; }
    public string? DamagePhotosJson { get; set; }
    public int FunctionalStatus { get; set; }
    public string? MissingPartsJson { get; set; }
    public int InspectionResult { get; set; }
    public string? RecommendedAction { get; set; }
    public decimal EstimatedRepairCost { get; set; }
    public string? Notes { get; set; }
}
