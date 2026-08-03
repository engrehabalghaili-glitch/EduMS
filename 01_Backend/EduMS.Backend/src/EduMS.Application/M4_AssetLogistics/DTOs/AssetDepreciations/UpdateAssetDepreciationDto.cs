using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetDepreciations;

public class UpdateAssetDepreciationDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int MethodType { get; set; }
    public int UsefulLifeYears { get; set; }
    public decimal DepreciationRate { get; set; }
    public decimal CurrentBookValue { get; set; }
    public decimal AccumulatedDepreciation { get; set; }
    public decimal NetBookValue { get; set; }
    public decimal DepreciableAmount { get; set; }
    public DateTime? LastDepreciationDate { get; set; }
    public string? LastDepreciationPeriod { get; set; }
    public bool IsFullyDepreciated { get; set; }
    public string? Notes { get; set; }
}
