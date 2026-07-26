using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetLoanTrackingAlerts;

public class UpdateAssetLoanTrackingAlertDto
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
}
