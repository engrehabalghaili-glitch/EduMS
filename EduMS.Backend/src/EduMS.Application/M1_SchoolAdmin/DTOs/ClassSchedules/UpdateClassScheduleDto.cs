using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassSchedules;

public class UpdateClassScheduleDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long ClassroomId { get; set; }
    public long SubjectId { get; set; }
    public long? AssignedEmployeeId { get; set; }
    public int DayOfWeek { get; set; }
    public int PeriodNumber { get; set; }
    public string? RoomCode { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public int TermSemesterNumber { get; set; }
    public int ScheduleType { get; set; }
    public bool IsActive { get; set; }
}
