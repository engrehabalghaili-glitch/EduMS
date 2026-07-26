using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الجدول الأسبوعي للمعلم - Teacher teaching schedule extracted from ZIP ERD TeacherSchedule table (lines 5681-5729).
/// </summary>
public class TeacherSchedule : BaseAuditableEntity
{
    public long TeacherEmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string DayOfWeek { get; set; } = string.Empty; // Saturday=1 ... Wednesday=5
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

    public virtual Employee? Teacher { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}
