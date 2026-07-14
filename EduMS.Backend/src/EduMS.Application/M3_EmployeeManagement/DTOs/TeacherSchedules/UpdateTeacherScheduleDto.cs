using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.TeacherSchedules;

public class UpdateTeacherScheduleDto
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
}
