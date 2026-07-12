using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الصفوف الدراسية والطاقة الاستيعابية - Grade-level capacity configuration extracted from ZIP ERD GradeCapacity table (lines 282-302).
/// Manages maximum students per class, section count, and enrollment tracking per grade.
/// </summary>
public class GradeCapacity : BaseAuditableEntity
{
    public long SchoolAcademicYearId { get; set; }
    public long SchoolLevelId { get; set; }
    public string GradeLevelCode { get; set; } = string.Empty;  // "1", "10" (Grade 1 Primary, Grade 1 Secondary)
    public string GradeNameAr { get; set; } = string.Empty;     // الأول الابتدائي
    public string? GradeNameEn { get; set; }
    public int MaxStudentsPerSection { get; set; }
    public int MaxSectionsCount { get; set; }
    public int CurrentEnrolledCount { get; set; }
    public int GenderAllocation { get; set; } = 1; // 1=Boys, 2=Girls, 3=Mixed
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual SchoolAcademicYear? AcademicYear { get; set; }
    public virtual SchoolLevel? SchoolLevel { get; set; }
}
