using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class EmergencyIncident : BaseAuditableEntity
{
    public long EmergencyPlanId { get; set; }
    public long SchoolId { get; set; }
    public long? ReportedByEmployeeId { get; set; }
    public string IncidentTitleAr { get; set; } = string.Empty;
    public DateTime IncidentDateTime { get; set; } = DateTime.UtcNow;
    public int SeverityLevel { get; set; } // 1=Low, 2=Medium, 3=High, 4=Critical
    public string ActionTakenSummary { get; set; } = string.Empty;

    // Cross-Module Navigation Properties
    public virtual EmergencyPlan? EmergencyPlan { get; set; }
    public virtual School? School { get; set; }
    public virtual Employee? ReportedByEmployee { get; set; }
}
