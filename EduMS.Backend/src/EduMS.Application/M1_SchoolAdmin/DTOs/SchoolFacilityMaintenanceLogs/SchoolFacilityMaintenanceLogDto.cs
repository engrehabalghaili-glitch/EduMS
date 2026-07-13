using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilityMaintenanceLogs;

public class SchoolFacilityMaintenanceLogDto
{
    public long Id { get; set; }
    public long SchoolFacilityId { get; set; }
    public string MaintenanceCode { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int MaintenanceType { get; set; }
    public string DescriptionDetails { get; set; } = string.Empty;
    public decimal TotalCostAmount { get; set; }
    public long? ResponsibleEmployeeId { get; set; }
    public string? ExternalContractorName { get; set; }
    public int Status { get; set; }
    public string? InspectionRemarks { get; set; }

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
