using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.GradingScaleBounds;

public class CreateGradingScaleBoundDto
{
    public long SchoolId { get; set; }
    public string ScaleName { get; set; }
    public string LetterCode { get; set; }
    public decimal MinPercentage { get; set; }
    public decimal MaxPercentage { get; set; }
    public decimal GradePointValue { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ScaleCode { get; set; }
    public bool IsPassingGrade { get; set; }
    public int DisplayOrder { get; set; }
}
