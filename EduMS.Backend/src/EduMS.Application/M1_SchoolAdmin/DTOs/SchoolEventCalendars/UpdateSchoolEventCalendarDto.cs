using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolEventCalendars;

public class UpdateSchoolEventCalendarDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string EventTitleAr { get; set; } = string.Empty;
    public string EventTitleEn { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EventType { get; set; }
    public bool IsPublic { get; set; }
    public string? Description { get; set; }
    public long? OrganizerEmployeeId { get; set; }
    public int TargetAudience { get; set; }
    public string? LocationDetails { get; set; }
    public bool RequiresAttendanceTracking { get; set; }
}
