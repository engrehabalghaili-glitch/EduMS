using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.MeetingAttendanceRecords;

public class MeetingAttendanceRecordDto
{
    public long Id { get; set; }
    public long MeetingId { get; set; }
    public long EmployeeId { get; set; }
    public bool IsAttended { get; set; }
    public string? AttendanceMethod { get; set; }
    public string? AbsenceReason { get; set; }
    public bool IsExcused { get; set; }
    public string? Notes { get; set; }
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
