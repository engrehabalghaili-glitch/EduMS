using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolShift : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ShiftNameAr { get; set; } = string.Empty;
    public string ShiftNameEn { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty; // e.g. "07:00"
    public string EndTime { get; set; } = string.Empty; // e.g. "13:30"
    public string? ShiftCode { get; set; }
    public int TotalPeriodsCount { get; set; } = 7;
    public int PeriodDurationMinutes { get; set; } = 45;
    public int BreakDurationMinutes { get; set; } = 30;
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public virtual School? School { get; set; }
}
