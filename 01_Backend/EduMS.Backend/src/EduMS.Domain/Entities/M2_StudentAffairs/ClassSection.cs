using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الشعب والفصول الدراسية (الوحدات التنظيمية) - Class section (section/stream) extracted from ZIP ERD ClassSection table.
/// Links Classroom (physical room) with GradeCapacity (grade level) and AcademicYear to form the operational section unit.
/// </summary>
public class ClassSection : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public long? GradeCapacityId { get; set; }
    public long? ClassroomId { get; set; }
    public string SectionCode { get; set; } = string.Empty;    // e.g. "5A", "10B"
    public string SectionNameAr { get; set; } = string.Empty;
    public string? SectionNameEn { get; set; }
    public int MaxStudents { get; set; }
    public int CurrentEnrolledCount { get; set; }
    public long? HomeroomTeacherEmployeeId { get; set; }
    public long? ShiftId { get; set; }
    public int SectionStatus { get; set; } = 1; // 1=Active, 2=Merged, 3=Closed
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual SchoolAcademicYear? AcademicYear { get; set; }
    public virtual Employee? HomeroomTeacherEmployee { get; set; }
}
