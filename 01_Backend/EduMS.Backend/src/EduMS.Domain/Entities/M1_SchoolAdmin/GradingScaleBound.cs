using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class GradingScaleBound : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ScaleName { get; set; } = string.Empty; // e.g. "Standard Secondary Scale"
    public string LetterCode { get; set; } = string.Empty; // e.g. "A+"
    public decimal MinPercentage { get; set; }
    public decimal MaxPercentage { get; set; }
    public decimal GradePointValue { get; set; } // e.g. 4.0
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ScaleCode { get; set; }
    public bool IsPassingGrade { get; set; } = true;
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public virtual School? School { get; set; }
}
