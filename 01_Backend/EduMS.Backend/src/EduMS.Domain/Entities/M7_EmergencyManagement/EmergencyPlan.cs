using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class EmergencyPlan : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public string PlanTitleAr { get; set; } = string.Empty;
    public string PlanTitleEn { get; set; } = string.Empty;
    public string EvacuationProcedureSummary { get; set; } = string.Empty;
    public DateTime NextScheduledDrillDate { get; set; }
    public bool IsActive { get; set; } = true;

    // Cross-Module Navigation Properties
    public virtual School? School { get; set; }
    public virtual ICollection<EmergencyIncident> Incidents { get; set; } = new List<EmergencyIncident>();
}
