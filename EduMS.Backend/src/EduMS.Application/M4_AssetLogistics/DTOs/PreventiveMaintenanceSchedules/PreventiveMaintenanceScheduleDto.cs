using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.PreventiveMaintenanceSchedules;

public class PreventiveMaintenanceScheduleDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ScheduleCode { get; set; } = string.Empty;
    public long? AssetId { get; set; }
    public long? AssetCategoryId { get; set; }
    public string TaskNameAr { get; set; } = string.Empty;
    public string? TaskNameEn { get; set; }
    public int MaintenanceType { get; set; }
    public int FrequencyUnit { get; set; }
    public decimal FrequencyValue { get; set; }
    public DateTime? NextDueDate { get; set; }
    public DateTime? LastServiceDate { get; set; }
    public int EstimatedDurationMinutes { get; set; }
    public string? AssignedToTeamText { get; set; }
    public string? InstructionsText { get; set; }
    public string? ChecklistJson { get; set; }
    public decimal EstimatedCost { get; set; }
    public long? MaintenanceContractId { get; set; }
    public bool IsReminderActive { get; set; } = true;
    public int ReminderDaysBefore { get; set; } = 7;
    public int ScheduleStatus { get; set; } = 1;
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
