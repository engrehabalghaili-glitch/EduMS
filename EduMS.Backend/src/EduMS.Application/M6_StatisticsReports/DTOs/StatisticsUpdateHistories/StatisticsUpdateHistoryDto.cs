using System;

namespace EduMS.Application.M6_StatisticsReports.DTOs.StatisticsUpdateHistories;

public class StatisticsUpdateHistoryDto
{
    public long Id { get; set; }
    public long? StatisticsDraftId { get; set; }
    public long? SubmittedStatisticsId { get; set; }
    public long SchoolId { get; set; }
    public string ChangeType { get; set; } = string.Empty;
    public string ChangeCategory { get; set; } = string.Empty;
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public DateTime ChangeDate { get; set; }
    public string? UpdateReason { get; set; }
    public string? SupportingDocumentUrl { get; set; }
    public long? ChangedByUserId { get; set; }
    public bool IsApproved { get; set; }
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
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
