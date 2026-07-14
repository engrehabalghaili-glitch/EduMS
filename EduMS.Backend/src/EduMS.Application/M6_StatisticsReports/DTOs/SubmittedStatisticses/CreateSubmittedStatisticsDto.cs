using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.SubmittedStatisticses;

public class CreateSubmittedStatisticsDto
{
    public long StatisticsDraftId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public string SubmissionNumber { get; set; } = string.Empty;
    public DateTime SubmissionTimestamp { get; set; } = DateTime.UtcNow;
    public int SubmissionMethod { get; set; }
    public long SubmittedByUserId { get; set; }
    public string? DirectorSignatureHash { get; set; }
    public DateTime? DirectorSignatureDate { get; set; }
    public string? StudentDataSnapshotJson { get; set; }
    public string? StaffDataSnapshotJson { get; set; }
    public string? FinancialSummarySnapshotJson { get; set; }
    public int ApprovalStatus { get; set; } = 1;
    public string? ReviewerNotes { get; set; }
    public DateTime? ReviewDate { get; set; }
    public long? ReviewedByUserId { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public bool IsFinal { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public string? Notes { get; set; }
}
