using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class VisitorEntryLog : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string VisitorFullName { get; set; } = string.Empty;
    public string NationalIdOrPassport { get; set; } = string.Empty;
    public string VisitPurpose { get; set; } = string.Empty;
    public long? HostEmployeeId { get; set; }
    public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
    public DateTime? CheckOutTime { get; set; }
    public string? VisitorBadgeNumber { get; set; }
    public int Status { get; set; } // 1=InCampus, 2=Departed, 3=Flagged
    public string? VisitorPhoneNumber { get; set; }
    public string? VisitorOrganization { get; set; }
    public string? SecurityGateNumber { get; set; }
    public long? SecurityOfficerEmployeeId { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Employee? HostEmployee { get; set; }
    public virtual Employee? SecurityOfficerEmployee { get; set; }
}
