using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAdditionalTasks;

public class EmployeeAdditionalTaskDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string TaskTitleAr { get; set; } = string.Empty;
    public string? TaskDescription { get; set; }
    public int TaskType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool HasFinancialCompensation { get; set; }
    public decimal CompensationAmount { get; set; }
    public long? AssignedByEmployeeId { get; set; }
    public int TaskStatus { get; set; } = 1;
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
