using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetMaintenanceTickets;

public class AssetMaintenanceTicketDto
{
    public long Id { get; set; }
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
