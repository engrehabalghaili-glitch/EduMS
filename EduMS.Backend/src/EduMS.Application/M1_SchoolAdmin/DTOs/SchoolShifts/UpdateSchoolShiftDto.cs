using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;

public class UpdateSchoolShiftDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ShiftNameAr { get; set; } = string.Empty;
    public string ShiftNameEn { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public string? ShiftCode { get; set; }
    public int TotalPeriodsCount { get; set; }
    public int PeriodDurationMinutes { get; set; }
    public int BreakDurationMinutes { get; set; }
    public bool IsActive { get; set; }
}
