using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialAuditArchives;

public class CreateAssetFinancialAuditArchiveDto
{
    public long SchoolId { get; set; }
    public int ReportType { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public DateTime GenerationDate { get; set; }
    public DateTime ArchivedDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAssetsValue { get; set; }
    public decimal TotalDepreciationValue { get; set; }
    public string? ReportFileUrl { get; set; }
    public bool IsReadOnly { get; set; } = true;
    public string? AuditStatus { get; set; }
    public string? AuditFirmName { get; set; }
    public DateTime? AuditDate { get; set; }
    public string? Notes { get; set; }
}
