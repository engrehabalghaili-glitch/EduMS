using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// المراحل الدراسية للمدرسة - School educational levels extracted from ZIP ERD SchoolLevel table (lines 90-108).
/// Distinct from the global EducationalStage lookup — this is school-specific level configuration.
/// </summary>
public class SchoolLevel : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string LevelNameAr { get; set; } = string.Empty;   // تمهيدي, ابتدائي, متوسط, ثانوي
    public string? LevelNameEn { get; set; }
    public int LevelOrder { get; set; }          // Display sequence
    public string StartGrade { get; set; } = string.Empty;   // e.g. Grade 1, KG1
    public string EndGrade { get; set; } = string.Empty;     // e.g. Grade 6
    public string? AcademicTrack { get; set; }   // General, Hafiz, International
    public int MinAgeYears { get; set; }
    public int MaxAgeYears { get; set; }
    public long? DefaultShiftId { get; set; }    // FK to SchoolShift
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // Navigation Property
    public virtual School? School { get; set; }
}
