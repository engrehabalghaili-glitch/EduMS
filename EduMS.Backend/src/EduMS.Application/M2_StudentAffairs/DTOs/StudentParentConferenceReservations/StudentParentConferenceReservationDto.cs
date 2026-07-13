using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentParentConferenceReservations;

public class StudentParentConferenceReservationDto
{
    public long Id { get; set; }
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
    public int ConferenceType { get; set; }
    public string? FollowUpActionItems { get; set; }
    public bool IsGuardianAttended { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
