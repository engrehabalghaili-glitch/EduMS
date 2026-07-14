using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolFacilityMaintenanceLogs;

public class UpdateSchoolFacilityMaintenanceLogDto
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
}
