using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.SubmittedStatisticses;

public class SubmittedStatisticsDto
{
    public long Id { get; set; }
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
