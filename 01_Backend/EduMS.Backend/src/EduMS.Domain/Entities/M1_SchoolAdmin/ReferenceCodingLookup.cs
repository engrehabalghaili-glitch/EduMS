using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الترميز المرجعي وقوائم البحث النظامية - Universal lookup / reference coding registry extracted from ZIP ERD ReferenceCoding table (lines 328-347).
/// Eliminates enum-duplications by centralising system-wide code lists (GENDER, STUDENT_STATUS, DOCUMENT_TYPE, etc.).
/// </summary>
public class ReferenceCodingLookup : BaseAuditableEntity
{
    public long? SchoolId { get; set; }          // null = global system code
    public string CodeType { get; set; } = string.Empty;  // e.g. GENDER, SCHOOL_TYPE, STUDENT_STATUS
    public string CodeKey { get; set; } = string.Empty;   // e.g. MALE, PUBLIC, ACTIVE
    public string CodeValueAr { get; set; } = string.Empty;
    public string? CodeValueEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public int SortOrder { get; set; }
    public bool IsSystemCode { get; set; }       // System codes cannot be deleted by users
    public bool IsActive { get; set; } = true;
    public long? ParentCodeId { get; set; }      // Self-referencing hierarchy
    public string? Notes { get; set; }

    // Navigation Property
    public virtual School? School { get; set; }
    public virtual ReferenceCodingLookup? ParentCode { get; set; }
    public virtual ICollection<ReferenceCodingLookup> SubCodes { get; set; } = new List<ReferenceCodingLookup>();
}
