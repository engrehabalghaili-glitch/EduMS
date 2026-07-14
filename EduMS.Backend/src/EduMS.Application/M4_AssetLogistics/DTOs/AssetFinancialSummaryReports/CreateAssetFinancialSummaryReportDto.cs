using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialSummaryReports;

public class CreateAssetFinancialSummaryReportDto
{
    public long SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public string ReportType { get; set; } = string.Empty;
    public long? AssetCategoryId { get; set; }
    public decimal TotalBookValue { get; set; }
    public decimal TotalDepreciation { get; set; }
    public decimal TotalAssetsCount { get; set; }
    public decimal TotalAcquisitionCost { get; set; }
    public int FullyDepreciatedAssetsCount { get; set; }
    public int AssetsWithImpairmentCount { get; set; }
    public string? RevaluationGains { get; set; }
    public string? RevaluationLosses { get; set; }
    public string AuditStatus { get; set; } = string.Empty;
    public string? AuditFirmName { get; set; }
    public string? AuditorName { get; set; }
    public DateTime? AuditDate { get; set; }
    public string? AuditorSignature { get; set; }
    public string? Notes { get; set; }
}
