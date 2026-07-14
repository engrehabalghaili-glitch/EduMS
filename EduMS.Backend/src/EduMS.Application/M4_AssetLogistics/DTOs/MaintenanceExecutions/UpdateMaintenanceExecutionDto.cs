using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceExecutions;

public class UpdateMaintenanceExecutionDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ExecutionNumber { get; set; } = string.Empty;
    public long? MaintenanceTicketId { get; set; }
    public long? PreventiveScheduleId { get; set; }
    public long AssetId { get; set; }
    public int ExecutionType { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public long ExecutedByEmployeeId { get; set; }
    public string WorkPerformedDescription { get; set; } = string.Empty;
    public string? SparePartsUsedJson { get; set; }
    public decimal MaintenanceCost { get; set; }
    public bool IsOperationalAfterMaintenance { get; set; }
    public long? NewAssetStatusId { get; set; }
    public string? ResolutionSummary { get; set; }
    public string? AttachmentsJson { get; set; }
    public int ExecutionStatus { get; set; } = 1;
    public string? Notes { get; set; }
}
