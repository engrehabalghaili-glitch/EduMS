using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.MeetingAttendanceRecords;

public class CreateMeetingAttendanceRecordDto
{
    public long MeetingId { get; set; }
    public long EmployeeId { get; set; }
    public bool IsAttended { get; set; }
    public string? AttendanceMethod { get; set; }
    public string? AbsenceReason { get; set; }
    public bool IsExcused { get; set; }
    public string? Notes { get; set; }
}
