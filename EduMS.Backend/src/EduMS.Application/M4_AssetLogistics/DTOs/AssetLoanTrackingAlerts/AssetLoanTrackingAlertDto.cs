using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetLoanTrackingAlerts;

public class AssetLoanTrackingAlertDto
{
    public long Id { get; set; }
    public long LoanId { get; set; }
    public long SchoolId { get; set; }
    public int AlertType { get; set; }
    public DateTime AlertDate { get; set; }
    public string AlertMessageText { get; set; } = string.Empty;
    public int DeliveryMethod { get; set; }
    public bool IsSent { get; set; }
    public string? SentToContact { get; set; }
    public bool IsAcknowledged { get; set; }
    public DateTime? AcknowledgedAt { get; set; }
    public bool ViolationRecorded { get; set; }
    public long? ViolationId { get; set; }
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
