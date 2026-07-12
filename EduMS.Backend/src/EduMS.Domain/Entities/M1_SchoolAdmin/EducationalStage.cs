using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class EducationalStage : BaseAuditableEntity
{
    public string StageCode { get; set; } = string.Empty; // e.g. "PRI", "SEC"
    public string StageNameAr { get; set; } = string.Empty;
    public string StageNameEn { get; set; } = string.Empty;
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public int DefaultDurationYears { get; set; }
    public string? MinistryCurriculumCode { get; set; }
    public bool RequiresGraduationCertificate { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Collection
    public virtual ICollection<School> Schools { get; set; } = new List<School>();
}
