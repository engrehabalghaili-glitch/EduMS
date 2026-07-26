using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetReceivings;

public class CreateAssetReceivingDto
{
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
}
