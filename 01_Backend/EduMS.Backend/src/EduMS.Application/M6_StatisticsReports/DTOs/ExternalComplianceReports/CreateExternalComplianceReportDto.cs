using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.ExternalComplianceReports;

public class CreateExternalComplianceReportDto
{
    public long SchoolId { get; set; }
    public string ReportNumber { get; set; } = string.Empty;
    public string TargetEntityName { get; set; } = string.Empty;
    public int EntityType { get; set; }
    public string? StandardType { get; set; }
    public int ReportType { get; set; }
    public string? PeriodStart { get; set; }
    public string? PeriodEnd { get; set; }
    public DateTime GenerationDate { get; set; } = DateTime.UtcNow;
    public long? GeneratedByUserId { get; set; }
    public string? FilePath { get; set; }
    public DateTime? SubmissionDate { get; set; }
    public int SubmissionMethod { get; set; }
    public string? ReceiptReference { get; set; }
    public DateTime? ReceiptDate { get; set; }
    public int SubmissionStatus { get; set; } = 1;
    public string? RejectionReason { get; set; }
    public bool IsFinal { get; set; }
    public DateTime? FinalApprovalDate { get; set; }
    public string? Notes { get; set; }
}
