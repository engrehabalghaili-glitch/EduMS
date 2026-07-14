using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentParentConferenceReservations;

public class CreateStudentParentConferenceReservationDto
{
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public long TeacherEmployeeId { get; set; }
    public long? SchoolEventCalendarId { get; set; }
    public DateTime ReservedDateTime { get; set; }
    public int MeetingDurationMinutes { get; set; }
    public string? DiscussionTopic { get; set; }
    public string? ConferenceNotes { get; set; }
    public int Status { get; set; }
    public string? MeetingRoomOrLink { get; set; }
    public int ConferenceType { get; set; } = 1;
    public string? FollowUpActionItems { get; set; }
    public bool IsGuardianAttended { get; set; }
}
