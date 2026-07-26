using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// تقارير القيمة المالية المجمعة للأصول - Asset financial summary reports extracted from ZIP ERD FinancialSummaryReports table (lines 7363-7389).
/// Standalone entity for consolidated asset book values, accumulated depreciation, and external/internal audit status.
/// </summary>
public class AssetFinancialSummaryReport : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public string ReportType { get; set; } = string.Empty; // Annual, Quarterly, OnDemand
    public long? AssetCategoryId { get; set; }
    public decimal TotalBookValue { get; set; }
    public decimal TotalDepreciation { get; set; }
    public decimal TotalAssetsCount { get; set; }
    public decimal TotalAcquisitionCost { get; set; }
    public int FullyDepreciatedAssetsCount { get; set; }
    public int AssetsWithImpairmentCount { get; set; }
    public string? RevaluationGains { get; set; }
    public string? RevaluationLosses { get; set; }
    public string AuditStatus { get; set; } = string.Empty; // Unaudited, InternallyAudited, ExternallyAudited, UnderAudit
    public string? AuditFirmName { get; set; }
    public string? AuditorName { get; set; }
    public DateTime? AuditDate { get; set; }
    public string? AuditorSignature { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual AssetCategory? AssetCategory { get; set; }
}
