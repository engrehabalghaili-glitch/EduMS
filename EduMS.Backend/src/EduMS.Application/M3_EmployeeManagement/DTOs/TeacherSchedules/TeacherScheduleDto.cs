using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.TeacherSchedules;

public class TeacherScheduleDto
{
    public long Id { get; set; }
    public long TeacherEmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string DayOfWeek { get; set; } = string.Empty;
    public long? ClassPeriodId { get; set; }
    public int PeriodNumber { get; set; }
    public long? SubjectId { get; set; }
    public long? ClassSectionId { get; set; }
    public long? GradeCapacityId { get; set; }
    public long? ClassroomId { get; set; }
    public bool IsSubstitute { get; set; }
    public long? OriginalTeacherEmployeeId { get; set; }
    public DateTime? SubstituteDate { get; set; }
    public string? SubstituteReason { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsCancelled { get; set; }
    public string? CancellationReason { get; set; }
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
