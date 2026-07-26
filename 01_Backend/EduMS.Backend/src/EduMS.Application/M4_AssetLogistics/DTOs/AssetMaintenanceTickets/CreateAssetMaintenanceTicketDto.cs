using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetMaintenanceTickets;

public class CreateAssetMaintenanceTicketDto
{
    public long SchoolId { get; set; }
    public string TicketNumber { get; set; } = string.Empty;
    public long AssetId { get; set; }
    public long ReportedByUserId { get; set; }
    public DateTime ReportDate { get; set; } = DateTime.UtcNow;
    public int IssueType { get; set; }
    public int SeverityLevel { get; set; }
    public string IssueDescriptionText { get; set; } = string.Empty;
    public long? AssignedToEmployeeId { get; set; }
    public DateTime? AssignedDate { get; set; }
    public string? Diagnosis { get; set; }
    public decimal EstimatedCost { get; set; }
    public DateTime? EstimatedCompletionDate { get; set; }
    public DateTime? ActualCompletionDate { get; set; }
    public string? ResolutionDetails { get; set; }
    public decimal ResolutionCost { get; set; }
    public int TicketStatus { get; set; } = 1;
    public long? ClosedByUserId { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string? AttachmentsJson { get; set; }
    public string? Notes { get; set; }
}
