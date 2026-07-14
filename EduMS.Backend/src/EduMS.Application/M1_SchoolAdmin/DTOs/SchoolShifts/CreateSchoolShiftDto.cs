using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;

public class CreateSchoolShiftDto
{
    public long SchoolId { get; set; }
    public string ShiftNameAr { get; set; }
    public string ShiftNameEn { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string? ShiftCode { get; set; }
    public int TotalPeriodsCount { get; set; }
    public int PeriodDurationMinutes { get; set; }
    public int BreakDurationMinutes { get; set; }
}
