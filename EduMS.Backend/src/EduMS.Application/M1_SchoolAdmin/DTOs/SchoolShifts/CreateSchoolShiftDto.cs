using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;

public class CreateSchoolShiftDto
{
    public long SchoolId { get; set; }
    public string ShiftNameAr { get; set; } = string.Empty;
    public string ShiftNameEn { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string? ShiftCode { get; set; }
    public int TotalPeriodsCount { get; set; } = 7;
    public int PeriodDurationMinutes { get; set; } = 45;
    public int BreakDurationMinutes { get; set; } = 30;
    public bool IsActive { get; set; } = true;
}
