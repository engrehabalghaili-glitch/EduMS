using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetRevaluationImpairments;

public class CreateAssetRevaluationImpairmentDto
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int OperationType { get; set; }
    public DateTime EffectiveDate { get; set; }
    public decimal OldBookValue { get; set; }
    public decimal OldAccumulatedDepreciation { get; set; }
    public decimal OldNetBookValue { get; set; }
    public decimal NewValue { get; set; }
    public decimal NewNetBookValue { get; set; }
    public decimal DifferenceAmount { get; set; }
    public int DifferenceType { get; set; }
    public string? ValuationFirmName { get; set; }
    public string? ValuationReportNumber { get; set; }
    public DateTime? ValuationReportDate { get; set; }
    public string? Reason { get; set; }
    public string? AttachmentUrl { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public int OperationStatus { get; set; } = 1;
    public string? Notes { get; set; }
}
