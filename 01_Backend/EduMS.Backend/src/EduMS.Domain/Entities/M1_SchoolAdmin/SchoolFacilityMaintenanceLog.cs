using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolFacilityMaintenanceLog : BaseAuditableEntity
{
    public long SchoolFacilityId { get; set; }
    public string MaintenanceCode { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int MaintenanceType { get; set; } // 1=Preventive, 2=CurativeRepair, 3=EmergencyInspection, 4=Upgrading
    public string DescriptionDetails { get; set; } = string.Empty;
    public decimal TotalCostAmount { get; set; }
    public long? ResponsibleEmployeeId { get; set; }
    public string? ExternalContractorName { get; set; }
    public int Status { get; set; } // 1=Scheduled, 2=InProgress, 3=Completed, 4=Cancelled
    public string? InspectionRemarks { get; set; }

    // Navigation Properties
    public virtual SchoolFacility? Facility { get; set; }
    public virtual Employee? ResponsibleEmployee { get; set; }
}
