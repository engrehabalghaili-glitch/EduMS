using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetReceivings;

public class AssetReceivingDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long PurchaseOrderId { get; set; }
    public string ReceivingNumber { get; set; } = string.Empty;
    public DateTime ReceivedDate { get; set; }
    public long ReceivedByEmployeeId { get; set; }
    public long? InspectorEmployeeId { get; set; }
    public string? DeliveryNoteNumber { get; set; }
    public string? DeliveryCompany { get; set; }
    public int InspectionResult { get; set; }
    public DateTime? InspectionDate { get; set; }
    public string? InspectionNotes { get; set; }
    public int DeliveryStatus { get; set; }
    public string? ReceivedItemsDetailsJson { get; set; }
    public string? RejectedItemsJson { get; set; }
    public bool ReturnRequested { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int FinalDecision { get; set; }
    public string? AttachmentsJson { get; set; }
    public int ReceivingStatus { get; set; } = 1;
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
