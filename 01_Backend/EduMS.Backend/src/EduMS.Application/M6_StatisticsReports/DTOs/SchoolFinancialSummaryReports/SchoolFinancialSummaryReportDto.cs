using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.SchoolFinancialSummaryReports;

public class SchoolFinancialSummaryReportDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string FiscalYear { get; set; } = string.Empty;
    public DateTime ReportDate { get; set; }
    public int ReportType { get; set; }
    public decimal TotalBookValue { get; set; }
    public decimal TotalDepreciation { get; set; }
    public int TotalAssetsCount { get; set; }
    public decimal TotalAcquisitionCost { get; set; }
    public decimal TotalRevaluationGains { get; set; }
    public decimal TotalImpairmentLosses { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal TotalExpenses { get; set; }
    public decimal NetIncome { get; set; }
    public string? AuditStatus { get; set; }
    public string? AuditFirmName { get; set; }
    public DateTime? AuditDate { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? FilePath { get; set; }
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
