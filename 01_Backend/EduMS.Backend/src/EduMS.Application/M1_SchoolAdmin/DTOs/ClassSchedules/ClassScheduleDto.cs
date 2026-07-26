using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ClassSchedules;

public class ClassScheduleDto
{
    // Base Entity
    public long Id { get; set; }

    // ClassSchedule Properties
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

    // Auditing Fields (From BaseAuditableEntity)
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    
    // Enum Representation as String
    public string SyncStatus { get; set; } = string.Empty;
}
