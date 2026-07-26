using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAttendances;

public class UpdateEmployeeAttendanceDto
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public string DayOfWeek { get; set; } = string.Empty;
    public long? ShiftId { get; set; }
    public DateTime? ExpectedCheckIn { get; set; }
    public DateTime? ExpectedCheckOut { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public int CheckInMethod { get; set; }
    public int CheckOutMethod { get; set; }
    public bool LocationVerified { get; set; }
    public string? CheckInLocationGps { get; set; }
    public string? AttendanceStatus { get; set; }
    public int LateMinutes { get; set; }
    public int EarlyDepartureMinutes { get; set; }
    public int OvertimeMinutes { get; set; }
    public bool IsOvertimeApproved { get; set; }
    public decimal TotalWorkHours { get; set; }
    public bool IsExcused { get; set; }
    public long? ExcuseLeaveId { get; set; }
    public string? ExcuseDocumentUrl { get; set; }
    public bool IsHoliday { get; set; }
    public bool IsWeekend { get; set; }
    public bool IsWorkingDay { get; set; }
    public bool IsOverridden { get; set; }
    public string? OverrideReason { get; set; }
    public long? OverriddenByUserId { get; set; }
    public bool IsSyncedWithPayroll { get; set; }
    public long? PayrollId { get; set; }
    public string? Notes { get; set; }
}
