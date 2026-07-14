using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyPlans;

public class UpdateEmergencyPlanDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public string PlanTitleAr { get; set; } = string.Empty;
    public string PlanTitleEn { get; set; } = string.Empty;
    public string EvacuationProcedureSummary { get; set; } = string.Empty;
    public DateTime NextScheduledDrillDate { get; set; }
    public bool IsActive { get; set; } = true;
}
