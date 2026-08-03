using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;

public class SchoolShiftDto
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
