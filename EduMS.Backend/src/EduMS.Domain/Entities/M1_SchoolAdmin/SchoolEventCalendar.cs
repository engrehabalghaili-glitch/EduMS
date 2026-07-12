using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolEventCalendar : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string EventTitleAr { get; set; } = string.Empty;
    public string EventTitleEn { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EventType { get; set; } // 1=Holiday, 2=ExamPeriod, 3=Conference, 4=Activity
    public bool IsPublic { get; set; } = true;
    public string? Description { get; set; }
    public long? OrganizerEmployeeId { get; set; }
    public int TargetAudience { get; set; } = 1; // 1=All, 2=Students, 3=Guardians, 4=Staff
    public string? LocationDetails { get; set; }
    public bool RequiresAttendanceTracking { get; set; }

    // Navigation Property
    public virtual School? School { get; set; }
}
