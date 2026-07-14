using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.AttendanceDetails;

public class UpdateAttendanceDetailDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long ClassroomId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public int AttendanceStatus { get; set; }
    public string? AbsenceReason { get; set; }
    public int DurationMinutes { get; set; }
    public long? RecordedByEmployeeId { get; set; }
    public int PeriodNumber { get; set; }
    public string? CheckInTime { get; set; }
    public string? CheckOutTime { get; set; }
    public bool IsParentNotified { get; set; }
    public string? ExcusalDocumentUrl { get; set; }
}
