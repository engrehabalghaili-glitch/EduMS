using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentParentConferenceReservation : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public long TeacherEmployeeId { get; set; }
    public long? SchoolEventCalendarId { get; set; }
    public DateTime ReservedDateTime { get; set; }
    public int MeetingDurationMinutes { get; set; }
    public string? DiscussionTopic { get; set; }
    public string? ConferenceNotes { get; set; }
    public int Status { get; set; } // 1=Confirmed, 2=Completed, 3=Cancelled
    public string? MeetingRoomOrLink { get; set; }
    public int ConferenceType { get; set; } = 1; // 1=InPerson, 2=OnlineVideo, 3=PhoneCall
    public string? FollowUpActionItems { get; set; }
    public bool IsGuardianAttended { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Guardian? Guardian { get; set; }
    public virtual Employee? TeacherEmployee { get; set; }
    public virtual SchoolEventCalendar? EventCalendar { get; set; }
}
